using Sanctuary.Services;

namespace Sanctuary.Web.Areas.NormalUsers.ViewModels.AppointmentCreation
{
    public class AppointmentViewModel
    {
        public AddressService service { get; set; }
        public AppointmentViewModel(AddressService service)
        {
            this.service = service;
        }
        public List<string?> TownNames => service.RetrieveTownsWithCountriesWhereClinicsAreEstablished();
    }
}
