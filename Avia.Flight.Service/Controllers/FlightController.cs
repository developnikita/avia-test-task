using System;
using Microsoft.AspNetCore.Mvc;

namespace Avia.Flight.Service.Controllers
{
    [ApiController]
    [Route("flights")]
    public class FlightController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<FlightTimeInfoDto> GetById(int id)
        {
            return new FlightTimeInfoDto("Какое-то название", DateTimeOffset.UtcNow, DateTimeOffset.Now);
        }
    }
}