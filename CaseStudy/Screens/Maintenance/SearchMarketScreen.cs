using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchMarketScreen : IScreen
    {
        private List<Flight> flights;

        public SearchMarketScreen()
        {
            flights = new List<Flight>(DataManager.GetInstance().GetFlights());
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY ORIGIN / DESTINATION");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Enter Origin / Destination Code: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();

            // TODO: Move search method to manager
            List<Flight> resultFlights = flights.FindAll(m => m.ArrivalStation == userInput || m.DepartureStation == userInput);
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
                    Console.WriteLine(flight.GetInfo());
                }
                Console.WriteLine("---------------------------------------------------");

                ScreenManager.GetInstance().PopScreen();
            }
        }
    }
}
