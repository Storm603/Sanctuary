using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.UserTables
{
    public class ClientUser
    {
        public ClientUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public List<Pet> PetOwnerships = new List<Pet>();
        public List<Invoice> Invoices = new List<Invoice>();
        public List<Appointment> AppointmentList = new List<Appointment>();

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public Clinic Clinic { get; set; }


        public string BaseUserId { get; set; }
        [ForeignKey(nameof(BaseUserId))]
        public BaseApplicationUser BaseApplicationUser { get; set; }

    }
}
