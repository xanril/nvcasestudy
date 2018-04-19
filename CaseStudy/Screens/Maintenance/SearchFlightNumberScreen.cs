using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchFlightNumberScreen : IScreen
    {
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
                Flight[] resultFlights = FlightDataManager.Instance.FindFlightsByFlightNumber(parsedFlightNumber);
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
            else
            {
                Console.WriteLine("Flight Numbers should only be numeric.");
            }
        }
    }
}
