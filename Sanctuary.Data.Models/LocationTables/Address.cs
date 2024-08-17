using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.UserTables;

namespace Sanctuary.Data.Models.LocationTables
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string? Country { get; set; }
        public string? Town { get; set; } 
        public Guid? PostalCodeInfoId { get; set; }
        [ForeignKey(nameof(PostalCodeInfoId))]
        public virtual PostalCodesCoordinates? PostalCodeInfo { get; set; }
        public string? District { get; set; }
        public string? StreetName { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }

        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual BaseApplicationUser? BaseUser { get; set; }

        public Guid? ClinicId { get; set; }
        [ForeignKey(nameof(ClinicId))]
        public virtual Clinic? Clinic { get; set; }
    }
}
