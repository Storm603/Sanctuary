using Sanctuary.Data.Models.ClinicTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Data.Models.UserTables
{
    public class ClinicStaffUser
    {
        public ClinicStaffUser()
        {
            Id = Guid.NewGuid().ToString();
            Schedule = new List<Appointment>();
            ClinicStaffLeaveRequest = new List<ClinicStaffLeave>();
            ClinicStaffLeaveReplace = new List<ClinicStaffLeave>();
        }
        public string Id { get; set; }

        public string? CabinetNumber { get; set; }
        public virtual List<Appointment> Schedule { get; set; }

        [Required]
        [Range(1, 35)]
        public int TotalPaidDaysLeave { get; set; }

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))] 
        public virtual Clinic Clinic { get; set; } = null!;

        [InverseProperty("RequestedBy")]
        public virtual List<ClinicStaffLeave>? ClinicStaffLeaveRequest { get; set; }
                                                              
        [InverseProperty("ReplacedBy")]                       
        public virtual List<ClinicStaffLeave>? ClinicStaffLeaveReplace { get; set; }


        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual BaseApplicationUser? BaseUser { get; set; }
    }
}
