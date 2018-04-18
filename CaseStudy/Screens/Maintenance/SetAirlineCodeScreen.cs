using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Maintenance.Screens
{
    class SetAirlineCodeScreen : IScreen
    {
        private Flight flight;

        public SetAirlineCodeScreen(Flight flight)
        {
            this.flight = flight;
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > ADD FLIGHT");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Airline Code: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();
            userInput = userInput.Trim();

            try
            {
                flight.AirlineCode = userInput;
                Console.WriteLine("Airline Code is now '" + flight.AirlineCode + "'\n");
                ScreenManager.GetInstance().PushScreen(new SetFlightNumberScreen(flight));
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
