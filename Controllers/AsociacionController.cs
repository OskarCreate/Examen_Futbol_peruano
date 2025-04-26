using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_Futbol_peruano.Data;
using Examen_Futbol_peruano.Models;

namespace Examen_Futbol_peruano.Controllers
{
    public class AsociacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsociacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asociacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asociaciones.Include(a => a.Equipo).Include(a => a.Jugador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Asociacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asociacion = await _context.Asociaciones
                .Include(a => a.Equipo)
                .Include(a => a.Jugador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asociacion == null)
            {
                return NotFound();
            }

            return View(asociacion);
        }

        // GET: Asociacion/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre");
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Nombre");
            return View();
        }

        // POST: Asociacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JugadorId,EquipoId,FechaAsignacion")] Asociacion asociacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asociacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre", asociacion.EquipoId);
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Nombre", asociacion.JugadorId);
            return View(asociacion);
        }

        // GET: Asociacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asociacion = await _context.Asociaciones.FindAsync(id);
            if (asociacion == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre", asociacion.EquipoId);
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Nombre", asociacion.JugadorId);
            return View(asociacion);
        }

        // POST: Asociacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JugadorId,EquipoId,FechaAsignacion")] Asociacion asociacion)
        {
            if (id != asociacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asociacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsociacionExists(asociacion.Id))
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
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre", asociacion.EquipoId);
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Nombre", asociacion.JugadorId);
            return View(asociacion);
        }

        // GET: Asociacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asociacion = await _context.Asociaciones
                .Include(a => a.Equipo)
                .Include(a => a.Jugador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asociacion == null)
            {
                return NotFound();
            }

            return View(asociacion);
        }

        // POST: Asociacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asociacion = await _context.Asociaciones.FindAsync(id);
            if (asociacion != null)
            {
                _context.Asociaciones.Remove(asociacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsociacionExists(int id)
        {
            return _context.Asociaciones.Any(e => e.Id == id);
        }
    }
}
