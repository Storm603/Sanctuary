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
    public class PetHotel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 1000)]
        public int HotelPlaces { get; set; }

        public List<PetHotelGuest> Pet { get; set; }

        [Required]
        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public Clinic Clinic { get; set; }
    }
}
