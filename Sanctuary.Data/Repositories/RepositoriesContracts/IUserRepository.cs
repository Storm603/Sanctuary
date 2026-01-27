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
        public Task<TUser> GetUserById(string userId);
        public Task<ClientUser> GetRelatedClientByBasePK(string userId);

    }
}
    