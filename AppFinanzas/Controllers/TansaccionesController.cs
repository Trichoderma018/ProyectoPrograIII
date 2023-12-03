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
    public class TansaccionesController : Controller
    {
        private readonly FinanzasContext _context;

        public TansaccionesController(FinanzasContext context)
        {
            _context = context;
        }

        // GET: Tansacciones
        public async Task<IActionResult> Index()
        {
            var finanzasContext = _context.Tansaccions.Include(t => t.Categoria).Include(t => t.Usuario);
            return View(await finanzasContext.ToListAsync());
        }

        // GET: Tansacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tansaccions == null)
            {
                return NotFound();
            }

            var tansaccion = await _context.Tansaccions
                .Include(t => t.Categoria)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tansaccion == null)
            {
                return NotFound();
            }

            return View(tansaccion);
        }

        // GET: Tansacciones/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Tansacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdCategoria,Descripcion,Monto,Fecha")] Tansaccion tansaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tansaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id", tansaccion.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", tansaccion.IdUsuario);
            return View(tansaccion);
        }

        // GET: Tansacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tansaccions == null)
            {
                return NotFound();
            }

            var tansaccion = await _context.Tansaccions.FindAsync(id);
            if (tansaccion == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id", tansaccion.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", tansaccion.IdUsuario);
            return View(tansaccion);
        }

        // POST: Tansacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdCategoria,Descripcion,Monto,Fecha")] Tansaccion tansaccion)
        {
            if (id != tansaccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tansaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TansaccionExists(tansaccion.Id))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "Id", "Id", tansaccion.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", tansaccion.IdUsuario);
            return View(tansaccion);
        }

        // GET: Tansacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tansaccions == null)
            {
                return NotFound();
            }

            var tansaccion = await _context.Tansaccions
                .Include(t => t.Categoria)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tansaccion == null)
            {
                return NotFound();
            }

            return View(tansaccion);
        }

        // POST: Tansacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tansaccions == null)
            {
                return Problem("Entity set 'FinanzasContext.Tansaccions'  is null.");
            }
            var tansaccion = await _context.Tansaccions.FindAsync(id);
            if (tansaccion != null)
            {
                _context.Tansaccions.Remove(tansaccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TansaccionExists(int id)
        {
          return (_context.Tansaccions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
