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
    public class ClinicStaffLeave
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AbscenceType { get; set; }
        public int Days { get; set; }
        public string Description { get; set; }


        [Required]
        public string RequestedById { get; set; }
        [ForeignKey(nameof(RequestedById))]
        public ClinicStaffUser RequestedBy { get; set; }



        public string ReplacedById { get; set; }
        [ForeignKey(nameof(ReplacedById))]
        public ClinicStaffUser? ReplacedBy { get; set; }

        
    }
}
