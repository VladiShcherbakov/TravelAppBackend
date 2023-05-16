using Microsoft.AspNetCore.Mvc;
using TravelApp.Services.TravelInfo;
using TravelApp.TravelApp.DTOModels.TravelInfo;

namespace TravelApp.Controllers
{
    [ApiController]
    [Route("/info")]
    public class TravelInfo : Controller
    {
        ITravelInfo _service;

        public TravelInfo(ITravelInfo service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTripInfo([FromForm] DTOTravelInfoCreate model)
        {
            try
            {
                await _service.CreateTravelInfo(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
