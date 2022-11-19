using Microsoft.AspNetCore.Mvc;

namespace Sanctuary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Route("/GetWeatherData")]
        public async Task<JsonResult> RapidApiWeatherData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?lat=43.853089&lon=25.963312&units=metric"),
                Headers =
                {
                    { "X-RapidAPI-Key", "46ce0afd0cmsh1b8cdc5a65d1bcfp173666jsnddf5b2ce9226" },
                    { "X-RapidAPI-Host", "weatherbit-v1-mashape.p.rapidapi.com" },
                },
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

            ;

            return new JsonResult(body);
        }
    }
}