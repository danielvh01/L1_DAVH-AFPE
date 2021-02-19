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
            return RedirectToAction(nameof(Index), ("Player"));
        }
        public IActionResult CsharpList()
        {
            Models.Data.Singleton.Instance.usingHandmadeList = false;
            return RedirectToAction(nameof(Index), ("Player"));
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

        public ActionResult DownloadFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("Times.log");
            string fileName = "Times.log";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}