
using GogoDriverWeb.Models;
using GogoWeb.Areas.Identity.Data;
using GogoWeb.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GogoWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly GogoWebContext _context;
        private readonly UserManager<GogoWebUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(GogoWebContext context,
              UserManager<GogoWebUser> userManager,
               RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        // GET: UsersController
        public async Task<IActionResult> IndexChauffeur()
        {
            var chauffeurs = await _userManager.GetUsersInRoleAsync("Chauffeur");

            return View(chauffeurs);
        }

        // GET: UsersController/Details/5
        public async Task<IActionResult> IndexPassager()
        {
            var passagers = await _userManager.GetUsersInRoleAsync("Passager");

            return View(passagers);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
