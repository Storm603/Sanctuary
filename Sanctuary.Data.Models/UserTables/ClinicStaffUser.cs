using Sanctuary.Data.Models.ClinicTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.LocationTables;

namespace Sanctuary.Data.Models.UserTables
{
    public class ClinicStaffUser
    {
        public ClinicStaffUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }


        public List<Appointment> Schedule = new List<Appointment>();

        public int TotalPaidDaysLeave { get; set; }

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public Clinic Clinic { get; set; }

        [InverseProperty("RequestedBy")]
        public List<ClinicStaffLeave> ClinicStaffLeaveRequest { get; set; }

        [InverseProperty("ReplacedBy")]
        public List<ClinicStaffLeave> ClinicStaffLeaveReplace { get; set; }


        public string BaseUserId { get; set; }
        [ForeignKey(nameof(BaseUserId))]
        public BaseApplicationUser BaseApplicationUser { get; set; }
    }
}
