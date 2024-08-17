using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(60)] 
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(60)] 
        public string Dosage { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
