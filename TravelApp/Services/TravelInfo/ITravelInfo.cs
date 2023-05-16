using TravelApp.TravelApp.DTOModels.TravelInfo;

namespace TravelApp.Services.TravelInfo
{
    public interface ITravelInfo
    {
        public Task CreateTravelInfo(DTOTravelInfoCreate model);
    }
}
