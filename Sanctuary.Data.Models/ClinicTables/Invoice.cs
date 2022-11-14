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
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ToId { get; set; }
        [ForeignKey(nameof(ToId))]
        public ClientUser To { get; set; }

        [Required]
        public Guid FromId { get; set; }
        [ForeignKey(nameof(FromId))]
        public Clinic From { get; set; }

        [Required]
        [MaxLength(16)]
        public string InvoiceNumber { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        public List<ClinicServices> ServicesUsed { get; set; }

        // removed clinic service list connection in ADdModelsPart1 migration
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice  { get; set; }
    }
}
