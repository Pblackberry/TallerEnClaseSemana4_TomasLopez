using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerEnClaseSemana4_TomasLopez.Models;

namespace TallerEnClaseSemana4_TomasLopez.Controllers
{
    public class EquiposController : Controller
    {
        private readonly LigaProContext _context;

        public EquiposController(LigaProContext context)
        {
            _context = context;
        }

        // GET: Equipos
        public async Task<IActionResult> Index()
        {
            var ligaProContext = _context.Equipos.Include(e => e.Estadio);
            return View(await ligaProContext.ToListAsync());
           // return View(await _context.Equipos.ToListAsync());
        }

        // GET: Equipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipos = await _context.Equipos
                .Include(e => e.Estadio)
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipos == null)
            {
                return NotFound();
            }

            return View(equipos);
        }

        // GET: Equipos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio");
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipo,Nombre,Ciudad,Titulos,AceptExtr,IdEstadio")] Equipos equipos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio", equipos.IdEstadio);
            return View(equipos);
        }

        // GET: Equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio", equipos.IdEstadio);
            return View(equipos);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipo,Nombre,Ciudad,Titulos,AceptExtr,IdEstadio")] Equipos equipos)
        {
            if (id != equipos.IdEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquiposExists(equipos.IdEquipo))
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
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio", equipos.IdEstadio);
            return View(equipos);
        }

        // GET: Equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipos = await _context.Equipos
                .Include(e => e.Estadio)
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipos == null)
            {
                return NotFound();
            }

            return View(equipos);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos != null)
            {
                _context.Equipos.Remove(equipos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquiposExists(int id)
        {
            return _context.Equipos.Any(e => e.IdEquipo == id);
        }
    }
}
