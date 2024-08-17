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

        public async Task<List<VetDTO>> GetAllVeterinariansByClinicName(string clinicName)
        {
            var vetsDTO = await DbSet.Include(x => x.Veterinary)
                .Where(x => x.Veterinary!.Clinic.ClinicName == clinicName)
                .Include(x => x.RelatedPictures)
                .Include(x => x.Roles)
                .Select(x => new VetDTO
                {
                    Id = x.Veterinary!.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    RoleName = x.Roles.ToList(),
                    PictureId = x.RelatedPictures.Where(x => x.IsProfilePicture).Select(x => x.Id).FirstOrDefault().ToString(),
                }).ToListAsync();

            return vetsDTO;
        }

        public async Task<List<TUser>> GetAllVeterinariansByUserRoleAndClinicId(string userRole, string clinicName)
        {
            clinicName = "SanctuaryZdravetc";

            var users = await DbSet.Include(x => x.RelatedPictures).Where(x => x.Veterinary!.Clinic.ClinicName == clinicName).ToListAsync();

            // needs to be more optimized for more efficient execution
            for (int i = users.Count - 1; i >= 0; i--)
            {
                if (await UserManager.IsInRoleAsync(users[i], userRole) == false)
                {
                    users.RemoveAt(i);
                }
            }

            return users;
        }



    }
}
