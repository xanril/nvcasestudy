using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Booking.Screens
{
    class SelectFlightScreen : IScreen
    {
        private Reservation reservation;

        public SelectFlightScreen(Reservation reservation)
        {
            this.reservation = reservation;
        }

        public void Display()
        {
            Console.WriteLine("\nRESERVATIONS > SELECT FLIGHT");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Airline Code and Flight Number (XX0000): ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();

            if(userInput.Length < 3)
            {
                Console.WriteLine("Invalid Flight Designator format. Please try again.");
                return;
            }

            string[] arrInputs = {
                                    userInput.Substring(0, 2),
                                    userInput.Substring(2)
                                 };

            string airlineCode = arrInputs[0];
            int flightNumber = 0;

            if(int.TryParse(arrInputs[1], out flightNumber))
            {
                Flight flight = DataManager.GetInstance().FindFlight(airlineCode, flightNumber);
                if(flight != null)
                {
                    Console.WriteLine("Flight record found.");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(flight.GetInfo());
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("");

                    reservation.flight = flight;
                    ScreenManager.GetInstance().PushScreen(new SetFlightPassengersScreen(reservation));
                }
                else
                {
                    Console.WriteLine("Flight record does not exist.");
                    ScreenManager.GetInstance().PopScreen();
                }
            }
            else
            {
                Console.WriteLine("Invalid Flight Designator format. Please try again.");
                return;
            }
        }

        
    }
}
