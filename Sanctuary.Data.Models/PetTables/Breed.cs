using System.ComponentModel.DataAnnotations;

namespace Sanctuary.Data.Models.PetTables
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)] 
        public string Name { get; set; } = null!;
    }
}
