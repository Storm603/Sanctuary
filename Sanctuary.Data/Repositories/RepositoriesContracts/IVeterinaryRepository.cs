using Sanctuary.Data.Models.UserTables;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IVeterinaryRepository<TUser> : IBaseRepository<TUser> where TUser : ClinicStaffUser
    {
        public Task<List<VetDTO>> GetAllVeterinariansByClinicName(string clinicName);

        public Task<List<TUser>> GetAllVeterinariansByUserRoleAndClinicId(string userRole, string clinicName);
    }
}
