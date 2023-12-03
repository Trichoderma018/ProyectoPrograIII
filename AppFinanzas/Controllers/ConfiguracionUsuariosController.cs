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
    public class ConfiguracionUsuariosController : Controller
    {
        private readonly FinanzasContext _context;

        public ConfiguracionUsuariosController(FinanzasContext context)
        {
            _context = context;
        }

        // GET: ConfiguracionUsuarios
        public async Task<IActionResult> Index()
        {
            var finanzasContext = _context.ConfiguracionUsuarios.Include(c => c.Usuario);
            return View(await finanzasContext.ToListAsync());
        }

        // GET: ConfiguracionUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConfiguracionUsuarios == null)
            {
                return NotFound();
            }

            var configuracionUsuario = await _context.ConfiguracionUsuarios
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configuracionUsuario == null)
            {
                return NotFound();
            }

            return View(configuracionUsuario);
        }

        // GET: ConfiguracionUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: ConfiguracionUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,LimiteGasto,NotificacionActiva")] ConfiguracionUsuario configuracionUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracionUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", configuracionUsuario.IdUsuario);
            return View(configuracionUsuario);
        }

        // GET: ConfiguracionUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConfiguracionUsuarios == null)
            {
                return NotFound();
            }

            var configuracionUsuario = await _context.ConfiguracionUsuarios.FindAsync(id);
            if (configuracionUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", configuracionUsuario.IdUsuario);
            return View(configuracionUsuario);
        }

        // POST: ConfiguracionUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,LimiteGasto,NotificacionActiva")] ConfiguracionUsuario configuracionUsuario)
        {
            if (id != configuracionUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracionUsuarioExists(configuracionUsuario.Id))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", configuracionUsuario.IdUsuario);
            return View(configuracionUsuario);
        }

        // GET: ConfiguracionUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConfiguracionUsuarios == null)
            {
                return NotFound();
            }

            var configuracionUsuario = await _context.ConfiguracionUsuarios
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configuracionUsuario == null)
            {
                return NotFound();
            }

            return View(configuracionUsuario);
        }

        // POST: ConfiguracionUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConfiguracionUsuarios == null)
            {
                return Problem("Entity set 'FinanzasContext.ConfiguracionUsuarios'  is null.");
            }
            var configuracionUsuario = await _context.ConfiguracionUsuarios.FindAsync(id);
            if (configuracionUsuario != null)
            {
                _context.ConfiguracionUsuarios.Remove(configuracionUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracionUsuarioExists(int id)
        {
          return (_context.ConfiguracionUsuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
