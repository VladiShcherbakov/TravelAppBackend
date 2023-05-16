using TravelApp.TravelApp.DTOModels.TravelPlan;

namespace TravelApp.Services.TravelPlan
{
    public interface ITravelPlan
    {
        public Task <List<DTOTravelPlan>> GetAllTravelPlansAsync();

        public Task CreateTravelPlanAsync(DTOTravelPlanCreate travelModel);

        public Task<DTOTravelPlan> GetTravelPlanWithInfo(int tripId);
    }
}
