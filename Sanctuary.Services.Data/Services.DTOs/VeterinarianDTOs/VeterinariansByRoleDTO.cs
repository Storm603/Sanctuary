using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Services.Data.Services.DTOs.VeterinarianDTOs
{
    public class VeterinariansByRoleDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ClinicName { get; set; } = null!;
        public string? ImageId { get; set; }
    }
}
