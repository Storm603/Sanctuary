using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class PetHotelGuest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfArrival { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfLeave { get; set; }

        [MaxLength(200)]
        public string? SpecialInstructions { get; set; }

        [Required]
        public Guid PetHotelId { get; set; }
        [ForeignKey(nameof(PetHotelId))]
        public PetHotel PetHotel { get; set; }

        [Required]
        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; }
    }
}
