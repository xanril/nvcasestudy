using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Screens
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
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT > SET AIRLINE CODE");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Airline Code or 'X' to go back: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();
            userInput = userInput.Trim();

            if (userInput == "X")
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreen();
                return;
            }

            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(flight, null, null) { MemberName = "AirlineCode" };
            bool isValid = Validator.TryValidateProperty(userInput, validationContext, validationResults);

            if(isValid)
            {
                flight.AirlineCode = userInput;
                Console.WriteLine("Airline Code is now '" + flight.AirlineCode + "'\n");
                ScreenManager.GetInstance().PushScreen(new SetFlightNumberScreen(flight));
            }
            else
            {
                foreach(ValidationResult result in validationResults)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
        }
    }
}
