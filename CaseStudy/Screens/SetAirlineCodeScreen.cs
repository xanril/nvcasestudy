using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Screens
{
    class SetAirlineCodeScreen : IScreen
    {
        private Flight newFlight;

        public SetAirlineCodeScreen(Flight flight)
        {
            this.newFlight = flight;
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
            ValidationContext validationContext = new ValidationContext(newFlight, null, null) { MemberName = "AirlineCode" };
            bool isValid = Validator.TryValidateProperty(userInput, validationContext, validationResults);

            if(isValid)
            {
                newFlight.AirlineCode = userInput;
                Console.WriteLine("Airline Code is now '" + newFlight.AirlineCode + "'\n");
                ScreenManager.GetInstance().PushScreen(new SetFlightNumberScreen(newFlight));
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
