using System;
using System.Globalization;
using Avia.Flight.Service.Entities;

namespace Avia.Flight.Service.Models.Extensions
{
    public static class FlightExtension
    {
        public static FlightInfo AsEntity(this FlightInfoCsv csvModel)
        {
            var arrivalDate = DateTime.ParseExact(csvModel.ArrivalDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            var departureDate = DateTime.ParseExact(csvModel.DepartureDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            var arrivalTime = DateTime.ParseExact(csvModel.ArrivalTime, "HHmm", CultureInfo.InvariantCulture);
            var departureTime = DateTime.ParseExact(csvModel.DepartureTime, "HHmm", CultureInfo.InvariantCulture);
            return new FlightInfo
            {
                Id = csvModel.Id,
                Destination = csvModel.Destination,
                Origin = csvModel.Origin,
                FlightName = csvModel.Number,
                ArrivalDate = new Date(arrivalDate.Year, arrivalDate.Month, arrivalDate.Day),
                ArrivalTime = new Time(arrivalTime.Hour, arrivalTime.Minute),
                DepartureDate = new Date(departureDate.Year, departureDate.Month, departureDate.Day),
                DepartureTime = new Time(departureTime.Hour, departureTime.Minute),
            };
        }
    }
}