using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class PromoCodes
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(16)]
        public string PromoCode { get; set; }

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }
    }
}
