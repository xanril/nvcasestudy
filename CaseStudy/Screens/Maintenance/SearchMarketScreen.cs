using CaseStudy.DataManagers;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchMarketScreen : IScreen
    {
        private Flight tempFlight;

        public SearchMarketScreen()
        {
            this.tempFlight = FlightDataManager.Instance.CreateFlight();
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
            ValidationHelperResult validationResult = null;

            validationResult = ValidationHelper.ValidateProperty<Flight>(tempFlight, nameof(tempFlight.DepartureStation), userInput);
            if (validationResult.HasError)
            {
                Console.Write(validationResult.GetErrorMessages());
                return;
            }

            Flight[] resultFlights = FlightDataManager.Instance.FindFlightsWithStation(userInput);
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
