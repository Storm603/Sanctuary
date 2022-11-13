using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class PetHotelGuest
    {
        public Guid Id { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public DateTime TimeOfLeave { get; set; }
        public string SpecialInstructions { get; set; }


        public Guid PetHotelId { get; set; }
        [ForeignKey(nameof(PetHotelId))]
        public PetHotel PetHotel { get; set; }

        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; }
    }
}
