using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Common.Models;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class PetHotelGuest : IAuditInfo, IDeletableEntity
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
        public virtual PetHotel PetHotel { get; set; } = null!;

        [Required]
        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
