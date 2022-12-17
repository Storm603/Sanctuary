using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sanctuary.Web.Views.ViewModels.APIViewModels
{
    public class MainDetails
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double TemperatureFeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TemperatureMinimum { get; set; }

        [JsonPropertyName("temp_max")]
        public double TemperatureMaximum { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
    }
}
