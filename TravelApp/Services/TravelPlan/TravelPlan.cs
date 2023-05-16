using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.Mail;
using TravelApp.TravelApp;
using TravelApp.TravelApp.DTOModels.TravelInfo;
using TravelApp.TravelApp.DTOModels.TravelPlan;
using TravelApp.TravelApp.Models;


namespace TravelApp.Services.TravelPlan
{
    public class TravelPlan : ITravelPlan
    {
        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TravelPlan(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task CreateTravelPlanAsync(DTOTravelPlanCreate travelModel)
        {
            var travelPlan = new TravelPlanModel
            {
                Name= travelModel.Name,
                Description= travelModel.Description,
                TripStart= travelModel.TripStart,
            };

            if (travelModel.Image != null)
            {
                var fileName = DateTime.Now.ToString("yyyyMMddhhmmssff");
                var fileExtension = Path.GetExtension(travelModel.Image.FileName);

                travelPlan.ImagePath = $"\\images\\{fileName + fileExtension}";

                var filePath = Path.Combine(_hostEnvironment.WebRootPath + travelPlan.ImagePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    travelModel.Image.CopyTo(fileStream);
                }
            }

            _context.Add(travelPlan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DTOTravelPlan>> GetAllTravelPlansAsync()
        {
            var tripPlans = await _context.TravelPlans.ToListAsync();

            var dtoTripPlans = tripPlans.Select(x => new DTOTravelPlan
            {
                Id = x.Id,
                Name= x.Name,
                Description= x.Description,
                TripStart= x.TripStart,
                ImagePath= x.ImagePath,
            }).ToList();

            return dtoTripPlans;
        }

        public async Task<DTOTravelPlan> GetTravelPlanWithInfo(int tripId)
        {
            var tripPlan = await _context.TravelPlans.Include(x => x.TravelInfos).FirstOrDefaultAsync(x => x.Id == tripId);

            var dtoTripPlan = new DTOTravelPlan
            {
                Name = tripPlan.Name,
                Description = tripPlan.Description,
                TripStart = tripPlan.TripStart,
                ImagePath = tripPlan.ImagePath,
                TravelInfos = tripPlan.TravelInfos.Select(x => new DTOTravelInfo
                {
                    Time= x.Time,
                    Title= x.Title,
                    Xid= x.Xid,
                }).ToList(),
            };

            return dtoTripPlan;
        }
    }
}
