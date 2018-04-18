using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchFlightNumberScreen : IScreen
    {
        private List<Flight> flights;

        public SearchFlightNumberScreen()
        {
            flights = new List<Flight>(DataManager.GetInstance().GetFlights());
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > SEARCH FLIGHT > BY FLIGHT NUMBER");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Flight Number or 'X' to go back: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();
            if(userInput == "X")
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreen();
                return;
            }

            int parsedFlightNumber = -1; 
            bool parseResult = int.TryParse(userInput, out parsedFlightNumber);

            if(parseResult)
            {
                List<Flight> resultFlights = flights.FindAll(m => m.FlightNumber == parsedFlightNumber);
                if (resultFlights == null || resultFlights.Count == 0)
                {
                    Console.WriteLine("No flight record found.");
                }
                else
                {
                    Console.WriteLine("Flight record/s found.");
                    foreach (Flight flight in resultFlights)
                    {
                        flight.PrintInfo();
                    }
                }
            }
            else
            {
                Console.WriteLine("Your input is invalid. Please try again.");
            }
        }
    }
}
