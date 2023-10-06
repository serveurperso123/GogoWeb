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
    public class PaiementsController : Controller
    {
        private readonly GogoWebContext _context;

        public PaiementsController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: Paiements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Paiements.Include(p => p.ModePaiementIdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Paiements/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Paiements == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiements
                .Include(p => p.ModePaiementIdNavigation)
                .FirstOrDefaultAsync(m => m.PaiementId == id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement);
        }

        // GET: Paiements/Create
        public IActionResult Create()
        {
            ViewData["ModePaiementId"] = new SelectList(_context.ModePaiements, "ModePaiementId", "ModePaiementId");
            return View();
        }

        // POST: Paiements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaiementId,ModePaiementId,MomtantPaiement,Telephone,DatePaiement,EtatPaiement,Facturation")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paiement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModePaiementId"] = new SelectList(_context.ModePaiements, "ModePaiementId", "ModePaiementId", paiement.ModePaiementId);
            return View(paiement);
        }

        // GET: Paiements/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Paiements == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiements.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }
            ViewData["ModePaiementId"] = new SelectList(_context.ModePaiements, "ModePaiementId", "ModePaiementId", paiement.ModePaiementId);
            return View(paiement);
        }

        // POST: Paiements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PaiementId,ModePaiementId,MomtantPaiement,Telephone,DatePaiement,EtatPaiement,Facturation")] Paiement paiement)
        {
            if (id != paiement.PaiementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paiement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiementExists(paiement.PaiementId))
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
            ViewData["ModePaiementId"] = new SelectList(_context.ModePaiements, "ModePaiementId", "ModePaiementId", paiement.ModePaiementId);
            return View(paiement);
        }

        // GET: Paiements/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Paiements == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiements
                .Include(p => p.ModePaiementIdNavigation)
                .FirstOrDefaultAsync(m => m.PaiementId == id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement);
        }

        // POST: Paiements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Paiements == null)
            {
                return Problem("Entity set 'GogoWebContext.Paiements'  is null.");
            }
            var paiement = await _context.Paiements.FindAsync(id);
            if (paiement != null)
            {
                _context.Paiements.Remove(paiement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiementExists(string id)
        {
            return (_context.Paiements?.Any(e => e.PaiementId == id)).GetValueOrDefault();
        }
    }
}
