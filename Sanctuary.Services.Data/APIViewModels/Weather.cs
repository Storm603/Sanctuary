using System.Text.Json.Serialization;

namespace Sanctuary.Web.Views.ViewModels.APIViewModels
{
    public class Weather
    {
        [JsonPropertyName("id")]
        public int WeatherId { get; set; }

        [JsonPropertyName("main")]
        public string? MainWeatherDescription { get; set; }

        [JsonPropertyName("description")]
        public string? WeatherDescription{ get; set; }

        [JsonPropertyName("icon")]
        public string? WeatherIcon { get; set; }
    }
}
