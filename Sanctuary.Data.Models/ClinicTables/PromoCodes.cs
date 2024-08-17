using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class PromoCodes
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(16)]
        public string? PromoCode { get; set; }

        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public virtual Clinic? Clinic { get; set; }
    }
}
