using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Common.Models;
using Sanctuary.Data.Models.PetTables;

namespace Sanctuary.Data.Models.ClinicTables
{
    public class HospitalizedPets : IAuditInfo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 10)]
        public string Description { get; set; } = null!;
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfSubmission { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfDischarge { get; set; }

        [Required] 
        public Guid ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public virtual Clinic Clinic { get; set; } = null!;

        //public Guid PetId { get; set; }
        //[ForeignKey(nameof(PetId))]
        public virtual Pet? Pet { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
