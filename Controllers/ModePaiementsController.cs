using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GogoWeb.Data;
using GogoDriverWeb.Models;

namespace GogoWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ModePaiementsController : Controller
    {
        private readonly GogoWebContext _context;

        public ModePaiementsController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: ModePaiements
        public async Task<IActionResult> Index()
        {
            return _context.ModePaiements != null ?
                        View(await _context.ModePaiements.ToListAsync()) :
                        Problem("Entity set 'GogoWebContext.ModePaiements'  is null.");
        }

        // GET: ModePaiements/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ModePaiements == null)
            {
                return NotFound();
            }

            var modePaiement = await _context.ModePaiements
                .FirstOrDefaultAsync(m => m.ModePaiementId == id);
            if (modePaiement == null)
            {
                return NotFound();
            }

            return View(modePaiement);
        }

        // GET: ModePaiements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModePaiements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModePaiementId,LibelleMode,Pourcentage")] ModePaiement modePaiement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modePaiement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modePaiement);
        }

        // GET: ModePaiements/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ModePaiements == null)
            {
                return NotFound();
            }

            var modePaiement = await _context.ModePaiements.FindAsync(id);
            if (modePaiement == null)
            {
                return NotFound();
            }
            return View(modePaiement);
        }

        // POST: ModePaiements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModePaiementId,LibelleMode,Pourcentage")] ModePaiement modePaiement)
        {
            if (id != modePaiement.ModePaiementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modePaiement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModePaiementExists(modePaiement.ModePaiementId))
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
            return View(modePaiement);
        }

        // GET: ModePaiements/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ModePaiements == null)
            {
                return NotFound();
            }

            var modePaiement = await _context.ModePaiements
                .FirstOrDefaultAsync(m => m.ModePaiementId == id);
            if (modePaiement == null)
            {
                return NotFound();
            }

            return View(modePaiement);
        }

        // POST: ModePaiements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ModePaiements == null)
            {
                return Problem("Entity set 'GogoWebContext.ModePaiements'  is null.");
            }
            var modePaiement = await _context.ModePaiements.FindAsync(id);
            if (modePaiement != null)
            {
                _context.ModePaiements.Remove(modePaiement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModePaiementExists(string id)
        {
            return (_context.ModePaiements?.Any(e => e.ModePaiementId == id)).GetValueOrDefault();
        }
    }
}
