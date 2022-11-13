using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public string ToId { get; set; }
        [ForeignKey(nameof(ToId))]
        public ClientUser To { get; set; }


        public Guid FromId { get; set; }
        [ForeignKey(nameof(FromId))]
        public Clinic From { get; set; }

        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        // removed clinic service list connection in ADdModelsPart1 migration

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice  { get; set; }
    }
}
