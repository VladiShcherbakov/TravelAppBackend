using Microsoft.AspNetCore.Mvc;
using TravelApp.Services.TravelPlan;
using TravelApp.TravelApp.DTOModels.TravelPlan;

namespace TravelApp.Controllers
{
    [ApiController]
    [Route("")]
    public class TravelPlan : ControllerBase
    {
        ITravelPlan _travelService;

        public TravelPlan(ITravelPlan travelService)
        {
            _travelService = travelService;
        }

        [HttpGet]
        [Route("home")]
        public async Task<ActionResult> GetAllTripPlans()
        {
            try
            {
                return Ok(await _travelService.GetAllTravelPlansAsync());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("planning")]
        public async Task<ActionResult> CreateTripPlan([FromForm] DTOTravelPlanCreate model)
        {
            try
            {
                await _travelService.CreateTravelPlanAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("info/{id:int}")]
        public async Task<ActionResult> GetTripWithInfo(int id)
        {
            try 
            {
                return Ok(await _travelService.GetTravelPlanWithInfo(id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}