using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Common.Models;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class Appointment : IAuditInfo, IDeletableEntity
    {
        public Appointment()
        {
            Services = new List<ClinicServices>();
            Pets = new List<Pet>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string AppointmentNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(DoctorId))]
        public string DoctorId { get; set; } = null!;
        public virtual ClinicStaffUser Doctor { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(ClientId))]
        public string ClientId { get; set; } = null!;
        public virtual ClientUser Client { get; set; } = null!;

        public virtual List<Pet> Pets { get; set; } = null!;

        public virtual List<ClinicServices> Services { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfAppointmentFrom { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfAppointmentTo { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Reason { get; set; } = null!;

        public string? PromoCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
