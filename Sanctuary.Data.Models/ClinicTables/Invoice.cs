using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class Invoice
    {
        public Invoice()
        {
            ServicesUsed = new List<ClinicServices>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required] 
        public string ReceiverId { get; set; } = null!;
        [ForeignKey(nameof(ReceiverId))] 
        public virtual ClientUser Receiver { get; set; } = null!;

        [Required]
        public Guid SenderId { get; set; }

        [ForeignKey(nameof(SenderId))] 
        public virtual Clinic Sender { get; set; } = null!;

        [Required] [MaxLength(16)] 
        public string InvoiceNumber { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        public virtual List<ClinicServices> ServicesUsed { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice  { get; set; }
    }
}
