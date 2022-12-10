using System.Security.Principal;

namespace Sanctuary.Web.Views.ViewModels.APIViewModels
{
    public class HomePageWeatherForecastDTO
    {
        public CommonDetails Main { get; set; }
        public Weather Weather { get; set; }

        public Wind Wind { get; set; }
    }
}
