using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Services.Contracts;
using Sanctuary.Services.Data.Services.API.DTO;

namespace Sanctuary.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AddressOperationsController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressOperationsController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        [Route("/[action]/{postalCode?}")]
        [EnableCors("Sanctuary.Web")]
        public async Task<IActionResult> GetAppointmentSearchBarSuggestions(string postalCode = "")
        {
            List<DetailedAddressDTO>? addressList = await addressService.GetDetailedAddressByZip(postalCode);

            return Ok(addressList);
        }
    }
}
