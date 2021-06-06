using System;

namespace Avia.Flight.Service
{
    public record FlightTimeInfoDto(string Name, DateTimeOffset DepartureTime, DateTimeOffset ArrivalTime);
}