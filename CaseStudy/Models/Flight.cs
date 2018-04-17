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
        [Range(minimum:1, maximum:9999, ErrorMessage = "Flight Number should be between the range of 1 to 9999.")]
        public int FlightNumber { get; set; }

        [Required(ErrorMessage = "Arrival Station should have a value.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage ="Arrival Station should have 3-character length.")]
        // TODO: add regex to accept alpha chars only?
        public string ArrivalStation { get; set; }

        [Required(ErrorMessage = "Departure Station should have a value.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Departure Station should have 3-character length.")]
        // TODO: add regex to accept alpha chars only?
        public string  DepartureStation { get; set; }

        // Required
        // Valid Time, 24-hour format
        public DateTime ScheduledTimeArrival;

        // Required
        // Valid Time, 24-Hour format
        public DateTime ScheduledTimeDeparture;

        public Flight(int id)
        {
            this.ID = id;

            // initial values
            this.AirlineCode = "A1";
            this.FlightNumber = 1;

            // set temp Scheduled time of departure and arrival
            DateTime tempDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.ScheduledTimeDeparture = tempDateTime.AddDays(1).AddHours(10);
            this.ScheduledTimeArrival = this.ScheduledTimeDeparture.AddHours(2);
        }

        public string GetFlightDesignator()
        {
            //TODO: Add flight number padding
            return AirlineCode + FlightNumber;
        }

        public string GetMarket()
        {
            return DepartureStation + "-" + ArrivalStation;
        }

        public string GetSchedule()
        {
            return ScheduledTimeDeparture.ToShortTimeString() + " - " + ScheduledTimeArrival.ToShortTimeString();
        }

        public void PrintInfo()
        {
            // TODO: should not do console out. refactor to return string instead
            string infoString = GetFlightDesignator() + "\t" + GetMarket() + "   " + GetSchedule();
            Console.WriteLine(infoString);
        }
    }
}
