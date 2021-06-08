namespace Avia.Flight.Service.Models
{
    // Для упрощения название свойство соответствуют названию столбцов в заголовке csv
    // можно так же задать их с помощью аннотаций []
    public class FlightInfoCsv
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string DepartureTime { get; set; }

        public string DepartureDate { get; set; }

        public string ArrivalDate { get; set; }

        public string ArrivalTime { get; set; }

        public string Number { get; set; }
    }
}