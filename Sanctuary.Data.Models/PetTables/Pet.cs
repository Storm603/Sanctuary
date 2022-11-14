using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.PetTables
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Breed Breed { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        public char? Sex { get; set; }
        public float? Weight { get; set; }
        [MaxLength(15)]
        public string? EyeColor { get; set; }
        [MaxLength(15)]
        public string? FurColor { get; set; }
        public bool? Microchip { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }


        public List<Allergies> Allergies = new List<Allergies>();


        public List<MedicalLog> MedicalLogs { get; set; }


        [Required] 
        public string ClientUserId { get; set; } = null!;
        [ForeignKey(nameof(ClientUserId))] 
        public ClientUser ClientUser { get; set; } = null!;
    }
}
