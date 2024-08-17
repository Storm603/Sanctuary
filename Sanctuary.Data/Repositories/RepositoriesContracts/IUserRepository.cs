using Sanctuary.Data.Models.UserTables;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;
using Sanctuary.Services.Data.Services.DTOs.VeterinarianDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IUserRepository<TUser> : IBaseRepository<TUser> where TUser : BaseApplicationUser
    {
        Task<List<TUser>> GetAllVeterinariansByUserRoleAndClinicId(string userRole, string clinicName);
        Task<List<VetDTO>> GetAllVeterinariansByClinicName(string clinicName);
    }
}
    