namespace TravelApp.TravelApp.DTOModels.TravelPlan
{
    public class DTOTravelPlanCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime TripStart { get; set; }

        public IFormFile Image { get; set; }
    }
}
