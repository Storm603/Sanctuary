using Sanctuary.Web.Views.ViewModels.APIViewModels;

namespace Sanctuary.Services.Contracts
{
    public interface IWeatherApi
    {
        public Task<List<HomePageWeatherForecastDTO>> HomePageWeatherDataRetrieval();
    }
}
