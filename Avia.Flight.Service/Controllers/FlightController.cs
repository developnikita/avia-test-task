using Avia.Flight.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avia.Flight.Service.Controllers
{
    [ApiController]
    [Route("flights")]
    public class FlightController : ControllerBase
    {
        public FlightController()
        {
        }

        [HttpGet("{id}")]
        public ActionResult<FlightTimeInfoDto> GetById(int id)
        {
            return new FlightTimeInfoDto("Какое-то название", new Time(10, 20), new Time(15, 0));
        }
    }
}