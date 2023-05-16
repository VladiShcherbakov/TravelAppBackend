using TravelApp.TravelApp;
using TravelApp.TravelApp.DTOModels.TravelInfo;
using TravelApp.TravelApp.Models;

namespace TravelApp.Services.TravelInfo
{
    public class TravelInfo : ITravelInfo
    {
        public readonly ApplicationDbContext _context;

        public TravelInfo(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
        }

        public async Task CreateTravelInfo(DTOTravelInfoCreate model)
        {
            var travelPlan = _context.TravelPlans.FirstOrDefault(x => x.Id == model.TravelPlanId);

            var travelInfo = new TravelInfoModel
            {
                PlanModel = travelPlan,
                Time= model.Time,
                Title= model.Title,
                Xid= model.Xid,
            };

            _context.Add(travelInfo);
            await _context.SaveChangesAsync();
        }
    }
}
