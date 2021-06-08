using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Avia.Flight.Service.Entities;
using Avia.Flight.Service.Entities.Extensions;
using Avia.Flight.Service.Models;
using Avia.Flight.Service.Repositories;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;

namespace Avia.Flight.Service.Controllers
{
    [ApiController]
    [Route("flights")]
    public class FlightController : ControllerBase
    {
        public FlightController(IReadOnlyRepository<FlightInfo> flightInfoRepository)
        {
            _flightInfoRepository = flightInfoRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<FlightTimeInfoDto> GetById(int id)
        {
            var result = _flightInfoRepository.Get(id);
            if (result == null)
                return BadRequest();

            return Ok(result.AsDto());
        }

        private readonly IReadOnlyRepository<FlightInfo> _flightInfoRepository;
    }
}