using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.ClinicTables;

namespace Sanctuary.Data.Models.PetTables
{
    public class MedicalLog
    {
        [Key]
        public Guid Id { get; set; }
        public string ReasonOfVisitation { get; set; }
        public DateTime DateAndTimeOfVisitation { get; set; }
        public List<Medicine> MedicineList { get; set; }

        public Guid PetId { get; set; }
        [ForeignKey(nameof(PetId))] 
        public Pet Pet { get; set; }
    }
}
