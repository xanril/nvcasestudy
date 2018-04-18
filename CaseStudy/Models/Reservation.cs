using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CaseStudy.Helpers;
using System;

namespace CaseStudy.Models
{
    class Reservation
    {
        public Flight flight;

        // Max 5 per booking
        private List<Passenger> passengers;
        public IEnumerable<Passenger> Passengers
        {
            get { return passengers; }
        }

        public string PNR
        {
            get; private set;
        }

        public Reservation()
        {
            this.passengers = new List<Passenger>();
            this.PNR = "GENERATE PLS";
        }

        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
        }

        public void SetPNR(string generatedPNR)
        {
            this.PNR = generatedPNR;
        }

        public string GetInfo()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("PNR: " + this.PNR);
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
