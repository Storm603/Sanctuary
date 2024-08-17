using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.PicturesTables
{
    public class ImageStorage
    {
        public ImageStorage()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [MaxLength(70)]
        public string PhotoName { get; set; } = null!;

        public Byte[]? Photo { get; set; }

        public bool IsProfilePicture { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public virtual BaseApplicationUser? User { get; set; }


        [ForeignKey(nameof(PetId))]
        public Guid? PetId { get; set; }
        public virtual Pet? Pet { get; set; }


        [ForeignKey(nameof(ClinicId))]
        public Guid? ClinicId { get; set; }
        public virtual Clinic? Clinic { get; set; }
    }
}
