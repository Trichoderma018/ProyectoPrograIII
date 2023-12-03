using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppFinanzas.Models;

namespace AppFinanzas.Controllers
{
    public class RolesPorUsuariosController : Controller
    {
        private readonly FinanzasContext _context;

        public RolesPorUsuariosController(FinanzasContext context)
        {
            _context = context;
        }

        // GET: RolesPorUsuarios
        public async Task<IActionResult> Index()
        {
            var finanzasContext = _context.RolesPorUsuarios.Include(r => r.Rol).Include(r => r.Usuario);
            return View(await finanzasContext.ToListAsync());
        }

        // GET: RolesPorUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RolesPorUsuarios == null)
            {
                return NotFound();
            }

            var rolesPorUsuario = await _context.RolesPorUsuarios
                .Include(r => r.Rol)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesPorUsuario == null)
            {
                return NotFound();
            }

            return View(rolesPorUsuario);
        }

        // GET: RolesPorUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: RolesPorUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdRol")] RolesPorUsuario rolesPorUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolesPorUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "Id", "Id", rolesPorUsuario.IdRol);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", rolesPorUsuario.IdUsuario);
            return View(rolesPorUsuario);
        }

        // GET: RolesPorUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RolesPorUsuarios == null)
            {
                return NotFound();
            }

            var rolesPorUsuario = await _context.RolesPorUsuarios.FindAsync(id);
            if (rolesPorUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "Id", "Id", rolesPorUsuario.IdRol);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", rolesPorUsuario.IdUsuario);
            return View(rolesPorUsuario);
        }

        // POST: RolesPorUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdRol")] RolesPorUsuario rolesPorUsuario)
        {
            if (id != rolesPorUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesPorUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesPorUsuarioExists(rolesPorUsuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "Id", "Id", rolesPorUsuario.IdRol);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", rolesPorUsuario.IdUsuario);
            return View(rolesPorUsuario);
        }

        // GET: RolesPorUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RolesPorUsuarios == null)
            {
                return NotFound();
            }

            var rolesPorUsuario = await _context.RolesPorUsuarios
                .Include(r => r.Rol)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesPorUsuario == null)
            {
                return NotFound();
            }

            return View(rolesPorUsuario);
        }

        // POST: RolesPorUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RolesPorUsuarios == null)
            {
                return Problem("Entity set 'FinanzasContext.RolesPorUsuarios'  is null.");
            }
            var rolesPorUsuario = await _context.RolesPorUsuarios.FindAsync(id);
            if (rolesPorUsuario != null)
            {
                _context.RolesPorUsuarios.Remove(rolesPorUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesPorUsuarioExists(int id)
        {
          return (_context.RolesPorUsuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
