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

        public string PNRNumber
        {
            get; private set;
        }

        private int passengerCount;

        [Range(1, 5, ErrorMessage = "Passenger count should be at least 1 to maximum of 5")]
        public int PassengerCount
        {
            get { return passengerCount; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Reservation>(this, nameof(PassengerCount), value);
                if(validationResult.IsValid)
                {
                    throw new Exception(validationResult.GetErrorMessages());
                }

                passengerCount = value;
            }
        }

        public Reservation()
        {
            this.passengers = new List<Passenger>();

            this.PNRNumber = "generate pls";
        }

        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
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
