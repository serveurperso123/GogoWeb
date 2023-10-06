
using GogoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GogoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> HomeAdmin()
        {
            return View();
        }

        public async Task<IActionResult> HomeChauffeur()
        {
            return View();
        }

        public async Task<IActionResult> HomeClient()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}