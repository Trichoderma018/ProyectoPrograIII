using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppFinanzas.Models
{
    public partial class FinanzasContext : DbContext
    {
        public FinanzasContext()
        {
        }

        public FinanzasContext(DbContextOptions<FinanzasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<ConfiguracionUsuario> ConfiguracionUsuarios { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<RolesPorUsuario> RolesPorUsuarios { get; set; } = null!;
        public virtual DbSet<Tansaccion> Tansaccions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= LAPTOP-H0PMSA49\\MSSQLSERVER01;Initial Catalog=Finanzas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.NombreCategoria).HasMaxLength(50);
            });

            modelBuilder.Entity<ConfiguracionUsuario>(entity =>
            {
                entity.ToTable("ConfiguracionUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ConfiguracionUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracionUsuario_Usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.NombreRol).HasMaxLength(50);
            });

            modelBuilder.Entity<RolesPorUsuario>(entity =>
            {
                entity.ToTable("RolesPorUsuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolesPorUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesPorUsuario_Rol");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RolesPorUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesPorUsuario_Usuario");
            });

            modelBuilder.Entity<Tansaccion>(entity =>
            {
                entity.ToTable("Tansaccion");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Tansaccions)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tansaccion_Categoria");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tansaccions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tansaccion_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Contrasena).HasMaxLength(80);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
