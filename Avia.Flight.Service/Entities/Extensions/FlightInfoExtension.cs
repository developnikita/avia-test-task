namespace Avia.Flight.Service.Entities.Extensions
{
    public static class Extensions
    {
        public static FlightTimeInfoDto AsDto(this FlightInfo flightInfo)
        {
            return new FlightTimeInfoDto(flightInfo.FlightName, flightInfo.DepartureTime, flightInfo.ArrivalTime);
        }
    }
}