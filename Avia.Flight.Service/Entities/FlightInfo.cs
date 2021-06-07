using Avia.Flight.Service.Models;

namespace Avia.Flight.Service.Entities
{
    public class FlightInfo : IEntity
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public Date DepartureDate { get; set; }

        public Time DepartureTime { get; set; }

        public Date ArrivalDate { get; set; }

        public Time ArrivalTime { get; set; }

        public string FlightName { get; set; }
    }
}