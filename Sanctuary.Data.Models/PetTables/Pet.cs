using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Common.Models;
using Sanctuary.Data.Models.PicturesTables;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.PetTables
{
    public class Pet : IAuditInfo, IDeletableEntity
    {
        public Pet()
        {
            Allergies = new List<Allergies>();
            MedicalLogs = new List<MedicalLog>();
            RelatedPictures = new List<ImageStorage>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required] 
        [MaxLength(50)] 
        public string Name { get; set; } = null!;

        public int BreedId { get; set; }
        [ForeignKey(nameof(BreedId))]
        public virtual Breed? Breed { get; set; }

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

        public virtual List<ImageStorage> RelatedPictures { get; set; }

        public virtual List<Allergies> Allergies { get; set; }

        public virtual List<MedicalLog> MedicalLogs { get; set; }

        [Required] 
        public string ClientUserId { get; set; } = null!;
        [ForeignKey(nameof(ClientUserId))] 
        public virtual ClientUser ClientUser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
