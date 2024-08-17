using Sanctuary.Data.Models.LocationTables;
using System.ComponentModel.DataAnnotations;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Models.PicturesTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class Clinic
    {
        public Clinic()
        {
            CreatedOn = DateTime.UtcNow;
            Users = new List<ClientUser>();
            Doctors = new List<ClinicStaffUser>();
            Invoices = new List<Invoice>();
            HospitalizedPets = new List<HospitalizedPets>();
            Services = new List<ClinicServices>();
            PromoCodes = new List<PromoCodes>();
            ClinicStaffLeaves = new List<ClinicStaffLeave>();
            RelatedPictures = new List<ImageStorage>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ClinicName { get; set; } = null!;

        [Required]
        public int HospitalizedPetCagedNumber { get; set; }

        public virtual Address? Address { get; set; }

        public virtual List<ClientUser> Users { get; set; }

        public virtual List<ClinicStaffUser> Doctors { get; set; }

        public virtual List<Invoice> Invoices { get; set; }

        public virtual List<HospitalizedPets> HospitalizedPets { get; set; }

        public virtual List<ClinicServices> Services { get; set; }

        public virtual List<PromoCodes> PromoCodes { get; set; }

        public virtual PetHotel? Hotel { get; set; }

        public virtual List<ClinicStaffLeave> ClinicStaffLeaves { get; set; }
        public virtual List<ImageStorage> RelatedPictures { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
