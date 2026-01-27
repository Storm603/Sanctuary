using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;

namespace Sanctuary.Data.Repositories
{
    public class VeterinaryRepository<TUser> : BaseRepository<TUser>, IVeterinaryRepository<TUser> where TUser : ClinicStaffUser
    {
        public VeterinaryRepository(ApplicationDbContext context) : base(context) {}

        public async Task<List<VetDTO>> GetAllVeterinariansByClinicName(string clinicName)
        {
            var vetsDTO = await DbSet.Include(x => x.Clinic)
                .Where(x => x.Clinic.ClinicName == clinicName)
                .Include(x => x.BaseUser!.RelatedPictures)
                .Include(x => x.BaseUser!.Roles)
                .Select(x => new VetDTO
                {
                    Id = x.Id,
                    FirstName = x.BaseUser!.FirstName,
                    LastName = x.BaseUser.LastName,
                    Email = x.BaseUser.Email,
                    PhoneNumber = x.BaseUser.PhoneNumber,
                    RoleName = x.BaseUser.Roles.ToList(),
                    PictureId = x.BaseUser.RelatedPictures.Where(x => x.IsProfilePicture).Select(x => x.Id).FirstOrDefault().ToString(),
                }).ToListAsync();

            return vetsDTO;
        }

        public async Task<List<TUser>> GetAllVeterinariansByUserRoleAndClinicId(string userRole, string clinicName)
        {
            var users = await DbSet.Include(x => x.BaseUser.RelatedPictures).Where(x => x.Clinic.ClinicName == clinicName).ToListAsync();

            // needs to be more optimized for more efficient execution
            for (int i = users.Count - 1; i >= 0; i--)
            {
                //if (await UserManager.IsInRoleAsync(users[i], userRole) == false)
                //{
                //    users.RemoveAt(i);
                //}
            }

            return users;
        }
    }
}
