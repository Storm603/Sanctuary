using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sanctuary.Web.Views.ViewModels.APIViewModels
{
    public class CommonDetails
    {
        [JsonPropertyName("list")]
        public List<HomePageWeatherForecastDTO> HomePageWeatherForecastDtos { get; set; }
    }
}
