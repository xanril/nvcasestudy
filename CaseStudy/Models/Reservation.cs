using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CaseStudy.Helpers;
using System;

namespace CaseStudy.Models
{
    public class Reservation
    {
        public Flight TargetFlight { get; set; }

        // Max 5 per booking
        private List<Passenger> passengers;
        public IEnumerable<Passenger> Passengers
        {
            get { return passengers; }
        }

        [StringLength(6, ErrorMessage = "PNR should have maximum of 6 characters only.")]
        [RegularExpression("([A-Z0-9])+", ErrorMessage = "PNR should only be composed of letters and numbers")]
        public string PNR { get; set; }

        public Reservation(string generatedPNR)
        {
            this.passengers = new List<Passenger>();
            this.PNR = generatedPNR;
        }

        public DateTime FlightDate { get; set; }

        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("PNR: " + this.PNR);
            strBuilder.AppendLine("Flight: " + TargetFlight.GetFlightDesignator());
            strBuilder.AppendLine("Date: " + FlightDate.ToShortDateString());
            int counter = 1;
            foreach (Passenger passenger in this.Passengers)
            {
                strBuilder.Append("Passenger " + counter + ": ");
                strBuilder.AppendLine(passenger.ToString());
                counter++;
            }

            return strBuilder.ToString();
        }
    }
}
