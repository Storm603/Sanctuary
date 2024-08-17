using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Web.ViewModels.AppointmentCreationViewModels
{
    public class SubmittedAppointmentViewModel
    {
        public SubmittedAppointmentViewModel()
        {
            PetIds = new List<string>();
        }
        public string AppointmentType { get; set; } = null!;
        public string ClinicName { get; set; } = null!;
        public List<string> PetIds { get; set; } = null!;
        public string VetId { get; set; } = null!;
    }
}
