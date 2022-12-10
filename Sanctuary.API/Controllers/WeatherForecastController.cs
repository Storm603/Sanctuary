using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sanctuary.Web.Views.ViewModels.APIViewModels;

namespace Sanctuary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Route("/GetWeatherData")]
        public async Task<JsonResult> OpenWeatherMapData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Rousse&appid=d0a44359ed6ad390e8f72e246d84ba93"),
            };
            
            using var response = await client.SendAsync(request);

            var body = string.Empty;

            try
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return null;
            }


            JObject obj = JObject.Parse(body);

            JToken results = obj["list"];
            HomePageWeatherForecastDTO dto = new HomePageWeatherForecastDTO()
            {
                Main = new CommonDetails() { }
            };

            return new JsonResult(body);

        }
    }
}