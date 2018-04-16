using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    class Flight
    {
        private const int MAX_AIRLINE_CODE_LENGTH = 2;

        public int ID { get; private set; }

        // Possible to extend to 3 chars max
        [Required(ErrorMessage = "Airline Code cannot be null.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Airline Code should be exactly 2 alphanumeric characters.")]
        [RegularExpression("[A-Z,a-z][0-9]|[0-9][A-Z,a-z]|[A-Z,a-z][A-Z,a-z]", ErrorMessage = "Airline Code cannot be both numbers.")]
        public string AirlineCode { get; set; }

        // Required
        [Range(minimum:1, maximum:9999, ErrorMessage = "Flight Number should be between the range of 1 to 9999")]
        public int FlightNumber;

        // Required
        public Station ArrivalStation;

        // Required
        public Station DepartureStation;

        // Required
        // Valid Time, 24-hour format
        public DateTime ScheduledTimeArrival;

        // Required
        // Valid Time, 24-Hour format
        public DateTime ScheduledTimeDeparture;

        public Flight(int id)
        {
            this.ID = id;

            // set temp Scheduled time of departure and arrival
            DateTime tempDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.ScheduledTimeDeparture = tempDateTime.AddDays(1).AddHours(10);
            this.ScheduledTimeArrival = this.ScheduledTimeDeparture.AddHours(2);
        }

        public string GetFlightDesignator()
        {
            return AirlineCode + FlightNumber;
        }

        public string GetMarket()
        {
            return DepartureStation.Code + "-" + ArrivalStation.Code;
        }

        public string GetSchedule()
        {
            return ScheduledTimeDeparture.ToShortTimeString() + " - " + ScheduledTimeArrival.ToShortTimeString();
        }

        public void PrintInfo()
        {
            string infoString = GetFlightDesignator() + "\t" + GetMarket() + "   " + GetSchedule();
            Console.WriteLine(infoString);
        }
    }
}
