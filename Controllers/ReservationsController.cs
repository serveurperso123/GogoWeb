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
using GogoWeb.Areas.Identity.Data;

namespace GogoWeb.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly GogoWebContext _context;

        public ReservationsController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservtions.Include(r => r.GogoWebUserIdNavigation).Include(r => r.TypeReservationIdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Reservtions == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservtions
                .Include(r => r.GogoWebUserIdNavigation)
                .Include(r => r.TypeReservationIdNavigation)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id");
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,PersonneId,TypeReservationId,DateReservation,HeureDebut,HeureFin,Position,NbrePassages")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", reservation.GogoWebUserId);
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId", reservation.TypeReservationId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Reservtions == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservtions.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", reservation.GogoWebUserId);
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId", reservation.TypeReservationId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReservationId,PersonneId,TypeReservationId,DateReservation,HeureDebut,HeureFin,Position,NbrePassages")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", reservation.GogoWebUserId);
            ViewData["TypeReservationId"] = new SelectList(_context.TypeReservations, "TypeReservationId", "TypeReservationId", reservation.TypeReservationId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Reservtions == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservtions
                .Include(r => r.GogoWebUserIdNavigation)
                .Include(r => r.TypeReservationIdNavigation)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Reservtions == null)
            {
                return Problem("Entity set 'GogoWebContext.Reservtions'  is null.");
            }
            var reservation = await _context.Reservtions.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservtions.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(string id)
        {
            return (_context.Reservtions?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }
    }
}
