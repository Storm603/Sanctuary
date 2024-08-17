using Microsoft.AspNetCore.Identity;

namespace Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs
{
    public class VetDTO
    {

        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<IdentityUserRole<string>> RoleName { get; set; } = null!;
        public string? PictureId { get; set; }
    }
}
