using TravelApp.TravelApp.DTOModels.TravelInfo;

namespace TravelApp.TravelApp.DTOModels.TravelPlan
{
    public class DTOTravelPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime TripStart { get; set; }

        public string ImagePath { get; set; }

        public List<DTOTravelInfo> TravelInfos { get; set; }
    }
}
