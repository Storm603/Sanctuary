using Microsoft.AspNetCore.Mvc;
using Sanctuary.Web.Models;
using System.Diagnostics;
using Sanctuary.Services;
using Sanctuary.Services.Contracts;

namespace Sanctuary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherAPI widget;

        public HomeController(ILogger<HomeController> logger, IWeatherAPI widget)
        {
            _logger = logger;
            this.widget = widget;
        }

        public IActionResult Index()
        {

            //List<HomePageWeatherForecastDTO>

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