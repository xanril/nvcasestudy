using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchAirlineCodeScreen : IScreen
    {
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

            Flight[] resultFlights = FlightDataManager.Instance.FindFlightsByAirlineCode(userInput);
            if (resultFlights == null || resultFlights.Length == 0)
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
                    Console.WriteLine(flight.ToString());
                }
                Console.WriteLine("---------------------------------------------------");

                ScreenManager.GetInstance().PopScreen();
            }
        }
    }
}
