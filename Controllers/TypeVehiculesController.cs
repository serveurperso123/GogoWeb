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
    public class TypeVehiculesController : Controller
    {
        private readonly GogoWebContext _context;

        public TypeVehiculesController(GogoWebContext context)
        {
            _context = context;
        }

        // GET: TypeVehicules
        public async Task<IActionResult> Index()
        {
            return _context.TypeVehicules != null ?
                        View(await _context.TypeVehicules.ToListAsync()) :
                        Problem("Entity set 'GogoWebContext.TypeVehicules'  is null.");
        }

        // GET: TypeVehicules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TypeVehicules == null)
            {
                return NotFound();
            }

            var typeVehicule = await _context.TypeVehicules
                .FirstOrDefaultAsync(m => m.TypevehiculeId == id);
            if (typeVehicule == null)
            {
                return NotFound();
            }

            return View(typeVehicule);
        }

        // GET: TypeVehicules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeVehicules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypevehiculeId,Standard,Vip")] TypeVehicule typeVehicule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeVehicule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeVehicule);
        }

        // GET: TypeVehicules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TypeVehicules == null)
            {
                return NotFound();
            }

            var typeVehicule = await _context.TypeVehicules.FindAsync(id);
            if (typeVehicule == null)
            {
                return NotFound();
            }
            return View(typeVehicule);
        }

        // POST: TypeVehicules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TypevehiculeId,Standard,Vip")] TypeVehicule typeVehicule)
        {
            if (id != typeVehicule.TypevehiculeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeVehicule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeVehiculeExists(typeVehicule.TypevehiculeId))
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
            return View(typeVehicule);
        }

        // GET: TypeVehicules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TypeVehicules == null)
            {
                return NotFound();
            }

            var typeVehicule = await _context.TypeVehicules
                .FirstOrDefaultAsync(m => m.TypevehiculeId == id);
            if (typeVehicule == null)
            {
                return NotFound();
            }

            return View(typeVehicule);
        }

        // POST: TypeVehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TypeVehicules == null)
            {
                return Problem("Entity set 'GogoWebContext.TypeVehicules'  is null.");
            }
            var typeVehicule = await _context.TypeVehicules.FindAsync(id);
            if (typeVehicule != null)
            {
                _context.TypeVehicules.Remove(typeVehicule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeVehiculeExists(string id)
        {
            return (_context.TypeVehicules?.Any(e => e.TypevehiculeId == id)).GetValueOrDefault();
        }
    }
}
