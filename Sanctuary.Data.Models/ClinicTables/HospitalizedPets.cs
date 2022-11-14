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
    public class HospitalizedPets
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Clinic Clinic { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HospitalizationTime { get; set; }

        [Required]
        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; }
    }
}
