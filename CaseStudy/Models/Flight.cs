using System;

namespace CaseStudy.Models
{
    class Flight
    {
        private const int MAX_AIRLINE_CODE_LENGTH = 2;

        public int ID
        {
            get; internal set;
        }

        // Required
        // Alphanumeric 
        // If first character is a digit, second character should be a letter 
        // Cannot be both numbers 
        // Exactly 2 characters
        // Possible to extend to 3 chars max
        public string AirlineCode;

        // Required
        // Numeric
        // Min: 1, Max = 9999
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

        public void SetAirlineCode(string airlineCode)
        {
            if (airlineCode.Length > MAX_AIRLINE_CODE_LENGTH)
            {
                throw new Exception("Airline Code should not exceed max length of " + MAX_AIRLINE_CODE_LENGTH);
            }


            //_airlineCode = airlineCode;
        }

        public void PrintInfo()
        {
            string infoString = GetFlightDesignator() + "\t" + GetMarket() + "   " + GetSchedule();
            Console.WriteLine(infoString);
        }
    }
}
