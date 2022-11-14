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
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public ClinicStaffUser Doctor { get; set; }

        [Required]
        public string ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public ClientUser Client { get; set; }

        public List<ClinicServices> Services = new List<ClinicServices>();


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfAppointment { get; set; }

        [Required]
        [StringLength(300,MinimumLength = 10)]
        public string Reason { get; set; }
        public string? PromoCode { get; set; }
    }
}
