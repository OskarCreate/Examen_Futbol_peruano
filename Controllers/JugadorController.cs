using Examen_Futbol_peruano.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_Futbol_peruano.Data;

namespace Examen_Futbol_peruano.Controllers
{
    public class JugadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jugador/Create
        public IActionResult Create()
        {
            ViewBag.Equipos = _context.Equipos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jugador jugador, int EquipoId)
        {
            if (ModelState.IsValid)
            {
                _context.Jugadores.Add(jugador);
                await _context.SaveChangesAsync();

                // Asociar jugador con equipo
                var asociacion = new Asociacion
                {
                    JugadorId = jugador.Id,
                    EquipoId = EquipoId
                };

                _context.Asociaciones.Add(asociacion);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Jugador");
            }

            ViewBag.Equipos = _context.Equipos.ToList();
            return View(jugador);
        }
        public IActionResult Index()
        {
            var jugadores = _context.Jugadores
                .Include(j => j.Asociaciones)
                .ThenInclude(a => a.Equipo)
                .ToList();
            return View(jugadores);
        }
    }
}
