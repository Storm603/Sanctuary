using Sanctuary.Services.Data.Services.API.DTO;

namespace Sanctuary.Services.API.APIContracts
{
    public interface IAPIGoogleGeocodingService
    {
        public Task<CoordinatesDTO> GetGAPILatitudeAndLongitudeByZipTownCountry(string locationInfo);
    }
}
    