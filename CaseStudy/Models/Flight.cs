using CaseStudy.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class Flight
    {
        private const int MAX_AIRLINE_CODE_LENGTH = 2;

        // Possible to extend to 3 chars max
        private string airlineCode;
        [Required(ErrorMessage = "Airline Code cannot be null.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Airline Code should be exactly 2 alphanumeric characters.")]
        [RegularExpression("[A-Z,a-z][0-9]|[0-9][A-Z,a-z]|[A-Z,a-z][A-Z,a-z]", ErrorMessage = "Airline Code cannot be both numbers.")]
        public string AirlineCode
        {
            get { return airlineCode; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Flight>(this, nameof(AirlineCode), value);
                if (validationResult.IsValid)
                    throw new Exception(validationResult.GetErrorMessages());

                airlineCode = value;
            }
        }

        // Required
        private int flightNumber;
        [Range(minimum:1, maximum:9999, ErrorMessage = "Flight Number should be between the range of 1 to 9999.")]
        public int FlightNumber
        {
            get { return flightNumber; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Flight>(this, nameof(FlightNumber), value);
                if (validationResult.IsValid)
                    throw new Exception(validationResult.GetErrorMessages());

                flightNumber = value;
            }
        }

        private string arrivalStation;
        [Required(ErrorMessage = "Arrival Station should have a value.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage ="Arrival Station should have 3-character length.")]
        [RegularExpression("([a-zA-Z])+", ErrorMessage = "Arrival Station should only be composed of letters.")]
        public string ArrivalStation
        {
            get { return arrivalStation; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Flight>(this, nameof(ArrivalStation), value);
                if (validationResult.IsValid)
                    throw new Exception(validationResult.GetErrorMessages());

                arrivalStation = value;
            }
        }

        private string departureStation;
        [Required(ErrorMessage = "Departure Station should have a value.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Departure Station should have 3-character length.")]
        [RegularExpression("([a-zA-Z])+", ErrorMessage = "Departure Station should only be composed of letters.")]
        public string  DepartureStation
        {
            get { return departureStation; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Flight>(this, nameof(DepartureStation), value);
                if (validationResult.IsValid)
                    throw new Exception(validationResult.GetErrorMessages());

                departureStation = value;
            }
        }

        // Required
        // Valid Time, 24-hour format
        public DateTime ScheduledTimeArrival;

        // Required
        // Valid Time, 24-Hour format
        public DateTime ScheduledTimeDeparture;

        public Flight()
        {
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

        public override string ToString()
        {
            string infoString = GetFlightDesignator() + "\t" + GetMarket() + "   " + GetSchedule();
            return infoString;
        }
    }
}
