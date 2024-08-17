using Sanctuary.Services.Data.Services.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Services.Contracts
{
    public interface IPostalCodeService
    {
        Task<List<string>?> GetPostalCodesStartingWithUnique(string postalCode);
    }
}
