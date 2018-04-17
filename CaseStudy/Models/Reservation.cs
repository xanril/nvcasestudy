using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Models
{
    class Reservation
    {
        public Flight flight;

        // Max 5 per booking
        public List<Passenger> Passengers;
        public string PNRNumber
        {
            get; internal set;
        }

        public Reservation()
        {
            this.Passengers = new List<Passenger>();

            this.PNRNumber = "generate pls";
        }

        public string GetInfo()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("PNR: " + this.PNRNumber);
            strBuilder.AppendLine("Flight: " + flight.GetFlightDesignator());
            int counter = 1;
            foreach (Passenger passenger in this.Passengers)
            {
                strBuilder.Append("Passenger " + counter + ": ");
                strBuilder.AppendLine(passenger.GetInfo());
                counter++;
            }
            
            return strBuilder.ToString();
        }
    }
}
