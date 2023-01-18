using Microsoft.AspNetCore.Mvc;
using Sanctuary.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Sanctuary.Services;
using Sanctuary.Services.Contracts;

namespace Sanctuary.Web.Controllers
{
    public class HomeController : Controller
    {
        public RoleManager<IdentityRole> rolemanager { get; set; }
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherApi widget;

        public HomeController(ILogger<HomeController> logger, IWeatherApi widget)
        {
            _logger = logger;
            this.widget = widget;
        }

        public IActionResult Index()
        {

            //List<HomePageWeatherForecastDTO>

            return View();
        }

        public IActionResult AboutUs()
        {
            return View("HomePageRedirects/AboutUs");
        }
        public IActionResult ClinicServices()
        {
            return View("HomePageRedirects/ClinicServices");
        }
        public IActionResult EcoCampaign()
        {
            return View("HomePageRedirects/EcoCampaign");
        }
        public IActionResult HomelessAnimals()
        {
            return View("HomePageRedirects/HomelessAnimals");
        }
        public IActionResult OurStaff()
        {
            return View("HomePageRedirects/OurStaff");
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