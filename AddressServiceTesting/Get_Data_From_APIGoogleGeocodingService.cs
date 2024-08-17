using Sanctuary.Services.API;
using Sanctuary.Services.API.APIContracts;
using Sanctuary.Services.Data.Services.API.DTO;

namespace AddressServiceTesting
{
    public class Tests
    {
        private IAPIGoogleGeocodingService? _service;
        [SetUp]
        public void SetUp()
        {
            _service = new APIGoogleGeocodingService();
        }

        [Test]
        public async Task Test1()
        {
            CoordinatesDTO data = await _service!.GetGAPILatitudeAndLongitudeByZipTownCountry("7005, Ruse, Bulgaria");

            Assert.That(data.lat == 43.852957 && data.lng == 25.9837327);
        }
    }
}
