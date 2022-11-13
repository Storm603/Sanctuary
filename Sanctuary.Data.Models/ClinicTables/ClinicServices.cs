using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class ClinicServices
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExecutionTime { get; set; }

        // call by role in identity asp
        public string SpecializedDoctor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public Clinic Clinic { get; set; }
    }
}
