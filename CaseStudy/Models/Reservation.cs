using System;
using System.Collections.Generic;

namespace CaseStudy.Models
{
    class Reservation
    {
        public int ID
        {
            get; internal set;
        }

        public Flight flight;

        // Max 5 per booking
        public List<Passenger> Passengers;
        public string PNRNumber
        {
            get; internal set;
        }

        public Reservation(int id)
        {
            this.ID = id;
            this.Passengers = new List<Passenger>();

            this.PNRNumber = "generate pls";
        }

        public void PrintInfo()
        {
            Console.WriteLine("PNR: " + this.PNRNumber);
            Console.WriteLine("Flight: " + flight.GetFlightDesignator());
            Console.WriteLine("Passengers:");
            foreach (Passenger passenger in this.Passengers)
            {
                Console.Write("\t");
                passenger.PrintInfo();
            }
        }
    }
}
