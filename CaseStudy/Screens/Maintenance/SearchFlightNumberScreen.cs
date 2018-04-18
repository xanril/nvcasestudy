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
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY FLIGHT NUMBER");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Flight Number: ");
        }

        public void ProcessInput(string userInput)
        {
            int parsedFlightNumber = -1; 
            bool parseResult = int.TryParse(userInput, out parsedFlightNumber);

            if(parseResult)
            {
                // TODO: Move search function to manager
                List<Flight> resultFlights = flights.FindAll(m => m.FlightNumber == parsedFlightNumber);
                if (resultFlights == null || resultFlights.Count == 0)
                {
                    Console.WriteLine("No flight record found.");
                    ScreenManager.GetInstance().PopScreen();
                }
                else
                {
                    Console.WriteLine("Flight record/s found.");
                    Console.WriteLine("---------------------------------------------------");
                    foreach (Flight flight in resultFlights)
                    {
                        flight.PrintInfo();
                    }
                    Console.WriteLine("---------------------------------------------------");

                    ScreenManager.GetInstance().PopScreen();
                }
            }
            else
            {
                Console.WriteLine("Flight Numbers should only be numeric.");
            }
        }
    }
}
