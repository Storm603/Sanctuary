using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class PetHotel
    {
        public PetHotel()
        {
            Pet = new List<PetHotelGuest>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 500)]
        public int HotelPlaces { get; set; }

        public virtual List<PetHotelGuest> Pet { get; set; }

        [Required]
        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))] 
        public virtual Clinic Clinic { get; set; } = null!;
    }
}
