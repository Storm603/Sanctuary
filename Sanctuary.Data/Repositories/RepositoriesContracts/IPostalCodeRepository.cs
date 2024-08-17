using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Services.Data.Services.API.DTO;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IPostalCodeRepository<TZipRepository> : IBaseRepository<TZipRepository> where TZipRepository : PostalCodesCoordinates
    {
        Task<List<string>> GetAllPostalCodes(string postalCode);
    }
}
