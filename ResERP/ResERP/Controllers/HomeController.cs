using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ResERP.Models;

namespace ResERP.Controllers
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
            //Check User Authentication and redirect page
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "main");
            } else
            {
                return View();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
