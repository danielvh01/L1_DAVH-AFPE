using Lab1_MLS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace Lab1_MLS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Handcrafted()
        {
            Models.Data.Singleton.Instance.usingHandmadeList = true;
            return RedirectToAction(nameof(Index), nameof(PlayerController));
        }
        public IActionResult CsharpList()
        {
            Models.Data.Singleton.Instance.usingHandmadeList = false;
            return RedirectToAction(nameof(Index), nameof(PlayerController));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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