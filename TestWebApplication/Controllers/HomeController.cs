using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApplication.Domain;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;

        public HomeController(ILogger<HomeController> logger, DataManager data)
        {
            _logger = logger;
            dataManager = data;
        }

        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetByCodeWord("PageIndex"));
        }

        public IActionResult Privacy()
        {
            return View(dataManager.TextFields.GetByCodeWord("PageContacts"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
