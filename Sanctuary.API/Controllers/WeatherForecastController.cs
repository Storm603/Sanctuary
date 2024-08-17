using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
                throw new Exception(e.Message);
            }


            //JObject obj = JObject.Parse(body);

            //JToken results = obj["list"];
            //List<HomePageWeatherForecastDTO> dto = new List<HomePageWeatherForecastDTO>();

            //foreach (JToken jtoken in results)
            //{
            //    var child = jtoken.Children();

            //    dto.Add(new HomePageWeatherForecastDTO()
            //    {
            //        Main = new MainDetails()
            //        {
            //            Temperature = (double)jtoken[0],
            //            TemperatureFeelsLike = (double)jtoken[1],
            //            TemperatureMinimum = (double)jtoken[2],
            //            TemperatureMaximum = (double)jtoken[3],
            //            Pressure = (double)jtoken[4],
            //            Humidity = (double)jtoken[7]
            //        }
            //    });
            //}

            return new JsonResult(body);

        }
    }
}