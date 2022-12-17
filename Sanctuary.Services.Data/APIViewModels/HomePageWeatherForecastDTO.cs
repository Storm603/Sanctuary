using System.Security.Principal;
using System.Text.Json.Serialization;

namespace Sanctuary.Web.Views.ViewModels.APIViewModels
{
    public class HomePageWeatherForecastDTO
    {
        [JsonPropertyName("list")]
        public MainDetails Main { get; set; }

        [JsonPropertyName("weather")] 
        public List<Weather> Weather = new List<Weather>();

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }
}
