using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Sanctuary.Services.Contracts;
using Sanctuary.Services.Data.DTO;

namespace Sanctuary.Services
{
    public class GeocodingApi : IGeocodingApi
    {
        public async Task<Location> GetLatitudeAndLongitudeByName(string countryAndTown)
        {
            string[] splittedResult = countryAndTown.Split(' ');

            string geoUrl = String.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0},{1}&key=AIzaSyDP64iLGi8Buh6jRZ6N8JG3ijxuQ-hk7F4", splittedResult[0], splittedResult[1]);

            HttpClient client = new HttpClient();

            var jsonFromWeatherAPI = await client.GetAsync(geoUrl);

            string json = await jsonFromWeatherAPI.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(json);

            Location locationLocated = new Location()
            {
                lat = (double) obj.SelectToken("$[results][geometry][location][0]"),
                lng = (double) obj.SelectToken("$[results][geometry][location][1]")
            };

            return locationLocated;
        }
    }
}
