using System.ComponentModel.DataAnnotations;
using Sanctuary.Data.Models.ClinicTables;

namespace Sanctuary.Data.Models.PetTables
{
    public class MedicalLog
    {
        public MedicalLog()
        {
            MedicineList = new List<Medicine>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required] 
        [MaxLength(300)] 
        public string ReasonOfVisitation { get; set; } = null!;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAndTimeOfVisitation { get; set; }
        public virtual List<Medicine> MedicineList { get; set; }

        //public Guid PetId { get; set; }
        //[ForeignKey(nameof(PetId))] 
        public virtual Pet? Pet { get; set; }
    }
}
