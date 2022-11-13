using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class HospitalizedPets
    {
        public Guid Id { get; set; }
        public Clinic Clinic { get; set; }
        public string Description { get; set; }
        public DateTime HospitalizationTime { get; set; }

        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; }
    }
}
