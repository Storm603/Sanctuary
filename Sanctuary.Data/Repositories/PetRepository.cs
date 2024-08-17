using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Data.Services.DTOs.AppointmentDTOs;

namespace Sanctuary.Data.Repositories
{
    public class PetRepository<TEntity> : IPetRepository<TEntity> where TEntity : Pet
    {
        private ApplicationDbContext Context;
        private DbSet<TEntity> DbSet;
        public PetRepository(ApplicationDbContext injContext)
        {
            Context = injContext;
            this.DbSet = this.Context.Set<TEntity>();
        }

        public async Task<List<PetDTO>> GetAllPetsOwnedByRegisteredUserByUserId(string userId)
        {
            List<PetDTO> listed = await DbSet
                .Include(x => x.ClientUser)
                .ThenInclude(x => x.BaseUser)
                .ThenInclude(x => x!.RelatedPictures)
                .Where(x => x.ClientUser.BaseUser!.Id == userId)
                .Select(x => new PetDTO
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Breed = x.Breed == null ? null : x.Breed.Name,
                    DateOfBirth = x.DateOfBirth,
                    Sex = x.Sex,
                    Weight = x.Weight,
                    EyeColour = x.EyeColor,
                    FurColour = x.FurColor,
                    Microchip = x.Microchip,
                    PictureId = x.RelatedPictures.Where(x => x.IsProfilePicture).Select(x => x.Id).FirstOrDefault().ToString(),
                }).ToListAsync();
            return listed;
        }
    }
}
