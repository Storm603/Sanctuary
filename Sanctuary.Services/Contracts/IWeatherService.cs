
namespace Sanctuary.Services.Contracts
{
    public interface IWeatherService
    {
        public Task<List<string>> HomePageWeatherDataRetrieval();   
    }
}
