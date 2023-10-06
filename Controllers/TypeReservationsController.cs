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
    [Authorize(Roles = "Admin")]
    public class TypeReservationsController : Controller
    {
        private readonly GogoWebContext _context;

        public TypeReservationsController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: TypeReservations
        public async Task<IActionResult> Index()
        {
            return _context.TypeReservations != null ?
                        View(await _context.TypeReservations.ToListAsync()) :
                        Problem("Entity set 'GogoWebContext.TypeReservations'  is null.");
        }

        // GET: TypeReservations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TypeReservations == null)
            {
                return NotFound();
            }

            var typeReservation = await _context.TypeReservations
                .FirstOrDefaultAsync(m => m.TypeReservationId == id);
            if (typeReservation == null)
            {
                return NotFound();
            }

            return View(typeReservation);
        }

        // GET: TypeReservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeReservationId,NomType,PrixUnitaire,TauxPeriodique")] TypeReservation typeReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeReservation);
        }

        // GET: TypeReservations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TypeReservations == null)
            {
                return NotFound();
            }

            var typeReservation = await _context.TypeReservations.FindAsync(id);
            if (typeReservation == null)
            {
                return NotFound();
            }
            return View(typeReservation);
        }

        // POST: TypeReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TypeReservationId,NomType,PrixUnitaire,TauxPeriodique")] TypeReservation typeReservation)
        {
            if (id != typeReservation.TypeReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeReservationExists(typeReservation.TypeReservationId))
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
            return View(typeReservation);
        }

        // GET: TypeReservations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TypeReservations == null)
            {
                return NotFound();
            }

            var typeReservation = await _context.TypeReservations
                .FirstOrDefaultAsync(m => m.TypeReservationId == id);
            if (typeReservation == null)
            {
                return NotFound();
            }

            return View(typeReservation);
        }

        // POST: TypeReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TypeReservations == null)
            {
                return Problem("Entity set 'GogoWebContext.TypeReservations'  is null.");
            }
            var typeReservation = await _context.TypeReservations.FindAsync(id);
            if (typeReservation != null)
            {
                _context.TypeReservations.Remove(typeReservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeReservationExists(string id)
        {
            return (_context.TypeReservations?.Any(e => e.TypeReservationId == id)).GetValueOrDefault();
        }
    }
}
