﻿using CaseStudy.Models;
using System;
using System.Collections.Generic;

namespace CaseStudy.Screens
{
    class SearchMarketScreen : IScreen
    {
        private List<Flight> _flights;

        public SearchMarketScreen()
        {
            _flights = new List<Flight>(DataManager.GetInstance().GetFlights());
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > SEARCH FLIGHT > BY ORIGIN / DESTINATION");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Origin / Destination Code or 'X' to go back: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();
            if (userInput == "X")
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreen();
                return;
            }

            List<Flight> resultFlights = _flights.FindAll(m => m.ArrivalStation.Code == userInput || m.DepartureStation.Code == userInput);
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
    }
}
