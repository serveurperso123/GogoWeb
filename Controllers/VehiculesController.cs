using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GogoDriverWeb.Models;
using Microsoft.AspNetCore.Authorization;
using GogoWeb.Data;

namespace GogoWeb.Controllers
{
    [Authorize]
    public class VehiculesController : Controller
    {
        private readonly GogoWebContext _context;

        public VehiculesController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: Vehicules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicules.Include(v => v.TypeReservationIdNavigation).Include(v => v.TypevehiculeIdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehicules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules
                .Include(v => v.TypeReservationIdNavigation)
                .Include(v => v.TypevehiculeIdNavigation)
                .FirstOrDefaultAsync(m => m.VehiculeId == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // GET: Vehicules/Create
        public IActionResult Create()
        {
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId");
            ViewData["TypevehiculeId"] = new SelectList(_context.TypeVehicules, "TypevehiculeId", "TypevehiculeId");
            return View();
        }

        // POST: Vehicules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehiculeId,TypevehiculeId,TypeReservationId,NomVehicule,Immatriculation,Couleur,Assurance,NumeroChassis,Marque")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId", vehicule.TypeReservationId);
            ViewData["TypevehiculeId"] = new SelectList(_context.TypeVehicules, "TypevehiculeId", "TypevehiculeId", vehicule.TypevehiculeId);
            return View(vehicule);
        }

        // GET: Vehicules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules.FindAsync(id);
            if (vehicule == null)
            {
                return NotFound();
            }
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId", vehicule.TypeReservationId);
            ViewData["TypevehiculeId"] = new SelectList(_context.TypeVehicules, "TypevehiculeId", "TypevehiculeId", vehicule.TypevehiculeId);
            return View(vehicule);
        }

        // POST: Vehicules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VehiculeId,TypevehiculeId,TypeReservationId,NomVehicule,Immatriculation,Couleur,Assurance,NumeroChassis,Marque")] Vehicule vehicule)
        {
            if (id != vehicule.VehiculeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculeExists(vehicule.VehiculeId))
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
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId", vehicule.TypeReservationId);
            ViewData["TypevehiculeId"] = new SelectList(_context.TypeVehicules, "TypevehiculeId", "TypevehiculeId", vehicule.TypevehiculeId);
            return View(vehicule);
        }

        // GET: Vehicules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules
                .Include(v => v.TypeReservationIdNavigation)
                .Include(v => v.TypevehiculeIdNavigation)
                .FirstOrDefaultAsync(m => m.VehiculeId == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // POST: Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vehicules == null)
            {
                return Problem("Entity set 'GogoWebContext.Vehicules'  is null.");
            }
            var vehicule = await _context.Vehicules.FindAsync(id);
            if (vehicule != null)
            {
                _context.Vehicules.Remove(vehicule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculeExists(string id)
        {
            return (_context.Vehicules?.Any(e => e.VehiculeId == id)).GetValueOrDefault();
        }
    }
}
