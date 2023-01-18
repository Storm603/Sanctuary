using Sanctuary.Data.Models.LocationTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class Clinic
    {
        public Clinic()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Key] 
        public Guid Id { get; set; }

        [Required]
        public string ClinicName { get; set; }

        [Required]
        public int HospitalizedPetCagedNumber { get; set; }

        public MT_Clinic_Addresses Address { get; set; }

        public List<ClientUser> Users = new List<ClientUser>();

        public List<ClinicStaffUser> Doctor = new List<ClinicStaffUser>();

        public List<Invoice> Invoices = new List<Invoice>();


        public List<HospitalizedPets> HospitalizedPets = new List<HospitalizedPets>();

        public List<ClinicServices> Services = new List<ClinicServices>();
        public List<PromoCodes> PromoCodes { get; set; }

        public PetHotel Hotel { get; set; }


        public List<ClinicStaffLeave> ClinicStaffLeaves { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
