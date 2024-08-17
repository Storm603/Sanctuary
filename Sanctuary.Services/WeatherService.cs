using System.Data.Entity;
using Sanctuary.Data;
using Sanctuary.Services.Contracts;

namespace Sanctuary.Services
{
    public class WeatherService : IWeatherService
    {
        private ApplicationDbContext Context { get; set; }
        public WeatherService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<List<string>> HomePageWeatherDataRetrieval()
        {
            HttpClient client = new HttpClient();

            var jsonFromWeatherAPI = await client.GetAsync("https://localhost:7253/GetWeatherData");

            string json = await jsonFromWeatherAPI.Content.ReadAsStringAsync();



            return new List<string>();
        }
    }
}
