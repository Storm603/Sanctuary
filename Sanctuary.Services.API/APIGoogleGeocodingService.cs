using Newtonsoft.Json.Linq;
using Sanctuary.Services.API.APIContracts;
using Sanctuary.Services.Data.Services.API.DTO;

namespace Sanctuary.Services.API
{   
    public class APIGoogleGeocodingService : IAPIGoogleGeocodingService
    {
        private HttpClient? _client;
        public async Task<CoordinatesDTO> GetGAPILatitudeAndLongitudeByZipTownCountry(string locationInfo)
        {
            // [0] = zip, [1] = town, [2] = country
            string[] splitResults = locationInfo.Split(", ");

            string geoUrl = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0},{1},{2}&key=AIzaSyDP64iLGi8Buh6jRZ6N8JG3ijxuQ-hk7F4", splitResults[0], splitResults[1], splitResults[2]);

            HttpResponseMessage? jsonReply = null;

            using (_client = new HttpClient())
            {
                jsonReply = await _client.GetAsync(geoUrl);
            }

            string jsonAsString = await jsonReply.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(jsonAsString);

            CoordinatesDTO coordinates = new CoordinatesDTO()
            {
                lat = (double)obj["results"]![0]!["geometry"]!["location"]!["lat"]!,
                lng = (double)obj["results"]![0]!["geometry"]!["location"]!["lng"]!,
            };

            return coordinates;
        }
    }
}
