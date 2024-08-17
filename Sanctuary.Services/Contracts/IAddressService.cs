using Sanctuary.Services.Data.Services.API.DTO;

namespace Sanctuary.Services.Contracts
{
    public interface IAddressService
    {
        Task<CoordinatesDTO?> GetZIPCoordinatesThroughPostalCodeAsync(string postalCode);
        Task<List<DetailedAddressDTO>?> GetDetailedAddressInZipRange(string postalCode);
        Task<List<ZipCoordinatesDTO>?> GetClinicPostalCodesFromSearchBar(string postalCode);
        Task<List<DetailedAddressDTO>?> GetDetailedAddressByZip(string postalCode);
    }
}
