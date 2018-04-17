using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Screens
{
    class SetFlightNumberScreen : IScreen
    {
        private static readonly string KEY_BACK_TO_MENU = "X";
        private Flight flight;

        public SetFlightNumberScreen(Flight flight)
        {
            this.flight = flight;
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT > SET FLIGHT NUMBER");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Flight Number or '" + KEY_BACK_TO_MENU + "' to go back: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();

            if (userInput == KEY_BACK_TO_MENU)
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreen();
                return;
            }

            // convert user input to int
            int intUserInput = -1;
            if(int.TryParse(userInput, out intUserInput))
            {
                // validate input
                List<ValidationResult> validationResults = new List<ValidationResult>();
                ValidationContext validationContext = new ValidationContext(flight, null, null) { MemberName = "FlightNumber" };
                bool isValid = Validator.TryValidateProperty(intUserInput, validationContext, validationResults);

                if(isValid)
                {
                    // check for duplicates
                    flight.FlightNumber = intUserInput;
                    bool hasDuplicateFlight = DataManager.GetInstance().HasDuplicateFlight(flight);
                    if(hasDuplicateFlight == false)
                    {
                        Console.WriteLine("Flight Number is now '" + flight.FlightNumber + "'\n");
                        ScreenManager.GetInstance().PushScreen(new SetDepartureStationScreen(flight));
                    }
                    else
                    {
                        Console.WriteLine("Flight " + flight.GetFlightDesignator() + "already exists.");
                    }
                }
                else
                {
                    // error validating. Print error messages
                    foreach (ValidationResult result in validationResults)
                    {
                        Console.WriteLine(result.ErrorMessage);
                    }
                }
            }
            else
            {
                Console.WriteLine("Flight Number should only contain numerical characters.");
            }
        }
    }
}
