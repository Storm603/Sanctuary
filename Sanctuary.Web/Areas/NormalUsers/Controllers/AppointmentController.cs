using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sanctuary.Services;
using Sanctuary.Services.Contracts;

namespace Sanctuary.Web.Areas.NormalUsers.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        public AddressService AddressService { get; set; }
        public GeocodingApi GeocodinService { get; set; }
        public AppointmentController(IAddressService addressService, IGeocodingApi geocodingService)
        {
            AddressService = (AddressService)addressService;
            GeocodinService = (GeocodingApi)geocodingService;
        }

        [HttpGet]
        public string GetLatitudeAndLongtituteInfo(string countryAndTownNames)
        {
            var result = GeocodinService.GetLatitudeAndLongitudeByName(countryAndTownNames);
            var serializer = new Newtonsoft.Json.JsonSerializer();
            //serializer.Serialize((Location));
            //return  serializer.ser
            return String.Empty;
        }

        [HttpGet]
        public IActionResult Appointment()
        {
            return View("/Areas/NormalUsers/Views/Appointment/AppointmentChooseTown.cshtml", new SelectList(AddressService.RetrieveTownsWithCountriesWhereClinicsAreEstablished()));
        }

        [HttpPost]
        public IActionResult Appointment(string zipCode)
        {
            int code = int.Parse(zipCode);
            return View("/Areas/NormalUsers/Views/Appointment/AppointmentFinalDetails.cshtml");
        }
    }
}
