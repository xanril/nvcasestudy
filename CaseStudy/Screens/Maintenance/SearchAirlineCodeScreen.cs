using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchAirlineCodeScreen : IScreen
    {
        private List<Flight> flights;

        public SearchAirlineCodeScreen()
        {
            flights = new List<Flight>(DataManager.GetInstance().GetFlights());
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY AIRLINE CODE");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Airline Code: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();
            // TODO: Add validation for airline code?

            // TODO: Move search function to manager
            List<Flight> resultFlights = flights.FindAll(m => m.AirlineCode == userInput);
            if(resultFlights == null || resultFlights.Count == 0)
            {
                Console.WriteLine("No flight record found.");
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
    }
}
