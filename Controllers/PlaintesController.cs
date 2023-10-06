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
    public class PlaintesController : Controller
    {
        private readonly GogoWebContext _context;

        public PlaintesController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: Plaintes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Plaintes.Include(p => p.GogoWebUserIdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Plaintes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Plaintes == null)
            {
                return NotFound();
            }

            var plainte = await _context.Plaintes
                .Include(p => p.GogoWebUserIdNavigation)
                .FirstOrDefaultAsync(m => m.PlainteId == id);
            if (plainte == null)
            {
                return NotFound();
            }

            return View(plainte);
        }

        // GET: Plaintes/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id");
            return View();
        }

        // POST: Plaintes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlainteId,PersonneId,LibellePlainte,DatePlainte")] Plainte plainte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plainte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", plainte.GogoWebUserId);
            return View(plainte);
        }

        // GET: Plaintes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Plaintes == null)
            {
                return NotFound();
            }

            var plainte = await _context.Plaintes.FindAsync(id);
            if (plainte == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", plainte.GogoWebUserId);
            return View(plainte);
        }

        // POST: Plaintes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlainteId,PersonneId,LibellePlainte,DatePlainte")] Plainte plainte)
        {
            if (id != plainte.PlainteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plainte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlainteExists(plainte.PlainteId))
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
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", plainte.GogoWebUserId);
            return View(plainte);
        }

        // GET: Plaintes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Plaintes == null)
            {
                return NotFound();
            }

            var plainte = await _context.Plaintes
                .Include(p => p.GogoWebUserIdNavigation)
                .FirstOrDefaultAsync(m => m.PlainteId == id);
            if (plainte == null)
            {
                return NotFound();
            }

            return View(plainte);
        }

        // POST: Plaintes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Plaintes == null)
            {
                return Problem("Entity set 'GogoWebContext.Plaintes'  is null.");
            }
            var plainte = await _context.Plaintes.FindAsync(id);
            if (plainte != null)
            {
                _context.Plaintes.Remove(plainte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlainteExists(string id)
        {
            return (_context.Plaintes?.Any(e => e.PlainteId == id)).GetValueOrDefault();
        }
    }
}
