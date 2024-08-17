using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Common.Models;
using Sanctuary.Data.Models.PicturesTables;

namespace Sanctuary.Data.Models.UserTables
{
    public class BaseApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public BaseApplicationUser()
        {
            base.Id = Guid.NewGuid().ToString();
            Roles = new HashSet<IdentityUserRole<string>>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
            RelatedPictures = new List<ImageStorage>();
            Tokens = new List<IdentityUserToken<string>>();
            CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(50)]
        [PersonalData]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [PersonalData]
        public string LastName { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual List<ImageStorage> RelatedPictures { get; set; }

        public virtual ClientUser? Client { get; set; }
        public virtual ClinicStaffUser? Veterinary { get; set; }

        public virtual Address? Address { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }

    }
}
