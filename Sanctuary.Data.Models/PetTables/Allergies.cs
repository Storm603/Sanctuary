using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Data.Models.PetTables
{
    public class Allergies
    {
        [Key]
        public int Id { get; set; }

        [Required] [MaxLength(40)] public string Type { get; set; } = null!;

        [Range(0, 5)]
        public int Severity { get; set; }

        //public Guid PetId { get; set; }
        //[ForeignKey(nameof(PetId))]
        public virtual Pet? Pet { get; set; }
    }
}
