using System;
using Avia.Flight.Service.Models;

namespace Avia.Flight.Service
{
    public record FlightTimeInfoDto(string Name, Time DepartureTime, Time ArrivalTime);
}