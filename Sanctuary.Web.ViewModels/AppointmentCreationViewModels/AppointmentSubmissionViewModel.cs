using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;

namespace Sanctuary.Web.ViewModels.AppointmentCreationViewModels
{
    public class AppointmentSubmissionViewModel
    {
        public AppointmentSubmissionViewModel()
        {
            OwnedPets = new List<PetDTO>();
            ClinicVets = new List<VetDTO>();
        }
        public string AppointmentType { get; set; } = null!;
        public string ClinicName { get; set; } = null!;
        public List<PetDTO> OwnedPets { get; set; } = null!;
        public List<VetDTO> ClinicVets { get; set; } = null!;
    }
}
