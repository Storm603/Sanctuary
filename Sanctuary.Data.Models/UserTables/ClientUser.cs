using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.UserTables
{
    public class ClientUser
    {
        public ClientUser()
        {
            Id = Guid.NewGuid().ToString();
            PetOwnerships = new List<Pet>();
            Invoices = new List<Invoice>();
            AppointmentList = new List<Appointment>();
        }
        public string Id { get; set; }

        public virtual List<Pet> PetOwnerships { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
        public virtual List<Appointment> AppointmentList { get; set; }

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public virtual Clinic? Clinic { get; set; }


        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual BaseApplicationUser? BaseUser { get; set; }

    }
}
