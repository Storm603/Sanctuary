using Sanctuary.Services.Contracts;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Common;
using System.Text.RegularExpressions;

namespace Sanctuary.Services
{
    public class PostalCodeService : IPostalCodeService
    {
        private IPostalCodeRepository<PostalCodesCoordinates> PostalCodeRepository { get; set; }

        public PostalCodeService(IPostalCodeRepository<PostalCodesCoordinates> postalCodeRepository)
        {
            PostalCodeRepository = postalCodeRepository;
        }

        public async Task<List<string>?> GetPostalCodesStartingWithUnique(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode) || !Regex.IsMatch(postalCode, RegexConstants.RegexNumbersOnly))
            {
                return null;
            }

            return await PostalCodeRepository.GetAllPostalCodes(postalCode);
        }
    }
}
