

using Newtonsoft.Json.Linq;
using Sanctuary.Services.Contracts;
using Sanctuary.Web.Views.ViewModels.APIViewModels;

namespace Sanctuary.Services
{
    public class WeatherAPI : IWeatherAPI
    {
        public async Task<List<HomePageWeatherForecastDTO>> HomePageWeatherDataRetrieval()
        {
            HttpClient client = new HttpClient();

            var jsonFromWeatherAPI = await client.GetAsync("https://localhost:7253/GetWeatherData");

            string json = await jsonFromWeatherAPI.Content.ReadAsStringAsync();



            return new List<HomePageWeatherForecastDTO>();
        }
    }
}
