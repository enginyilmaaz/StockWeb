using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Stock.Web.Controllers
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
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ErrorOccured()
        {

            return View();
        }

    }
}
