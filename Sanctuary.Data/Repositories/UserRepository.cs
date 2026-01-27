using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.Configurable;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;

namespace Sanctuary.Data.Repositories
{
    public class UserRepository<TUser> : BaseRepository<TUser>, IUserRepository<TUser> where TUser : BaseApplicationUser
    {
        private UserManager<TUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public UserRepository(ApplicationDbContext injContext, UserManager<TUser> injUserManager, RoleManager<ApplicationRole> injRoleManager) : base(injContext)
        {
            UserManager = injUserManager;
            RoleManager = injRoleManager;
        }



        public async Task<TUser> GetUserById(string userId)
        {
            return await DbSet.Where(x => x.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<ClientUser> GetRelatedClientByBasePK(string userId)
        {
            return await DbSet.Include(x => x.Client).Where(x => x.Id == userId).Select(x => x.Client).FirstOrDefaultAsync();
        }

    }
}
