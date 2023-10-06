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
    public class SoesController : Controller
    {
        private readonly GogoWebContext _context;

        public SoesController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: Soes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sos.Include(s => s.PersonneIdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Soes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sos == null)
            {
                return NotFound();
            }

            var so = await _context.Sos
                .Include(s => s.PersonneIdNavigation)
                .FirstOrDefaultAsync(m => m.SoId == id);
            if (so == null)
            {
                return NotFound();
            }

            return View(so);
        }

        // GET: Soes/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id");
            return View();
        }

        // POST: Soes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoId,PersonneId,Localisation,Description")] So so)
        {
            if (ModelState.IsValid)
            {
                _context.Add(so);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", so.GogoWebUserId);
            return View(so);
        }

        // GET: Soes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sos == null)
            {
                return NotFound();
            }

            var so = await _context.Sos.FindAsync(id);
            if (so == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", so.GogoWebUserId);
            return View(so);
        }

        // POST: Soes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SoId,PersonneId,Localisation,Description")] So so)
        {
            if (id != so.SoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(so);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoExists(so.SoId))
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
            ViewData["PersonneId"] = new SelectList(_context.Set<GogoWebUser>(), "Id", "Id", so.GogoWebUserId);
            return View(so);
        }

        // GET: Soes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sos == null)
            {
                return NotFound();
            }

            var so = await _context.Sos
                .Include(s => s.PersonneIdNavigation)
                .FirstOrDefaultAsync(m => m.SoId == id);
            if (so == null)
            {
                return NotFound();
            }

            return View(so);
        }

        // POST: Soes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sos == null)
            {
                return Problem("Entity set 'GogoWebContext.Sos'  is null.");
            }
            var so = await _context.Sos.FindAsync(id);
            if (so != null)
            {
                _context.Sos.Remove(so);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoExists(string id)
        {
            return (_context.Sos?.Any(e => e.SoId == id)).GetValueOrDefault();
        }
    }
}
