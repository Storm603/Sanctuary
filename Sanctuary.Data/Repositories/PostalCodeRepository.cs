using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Data.Services.API.DTO;

namespace Sanctuary.Data.Repositories
{
    public class PostalCodeRepository<TZipRepository> : BaseRepository<TZipRepository>, IPostalCodeRepository<TZipRepository> where TZipRepository : PostalCodesCoordinates
    {
        public PostalCodeRepository(ApplicationDbContext context) : base(context){}

        public async Task<List<string>> GetAllPostalCodes(string postalCode)
        {
            return await DbSet.Where(x => x.PostalCode.StartsWith(postalCode)).Select(x => x.PostalCode).ToListAsync();
        }
    }
}
