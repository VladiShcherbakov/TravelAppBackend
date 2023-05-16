namespace TravelApp.TravelApp.DTOModels.TravelInfo
{
    public class DTOTravelInfoCreate
    {
        public string Title { get; set; }

        public string Xid { get; set; }

        public DateTime Time { get; set; }

        public int TravelPlanId { get; set; }
    }
}
