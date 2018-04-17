﻿using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Screens
{
    class SetFlightNumberScreen : IScreen
    {
        private const string KEY_BACK_TO_MENU = "X";
        private Flight newFlight;

        public SetFlightNumberScreen(Flight flight)
        {
            this.newFlight = flight;
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
                ValidationContext validationContext = new ValidationContext(newFlight, null, null) { MemberName = "FlightNumber" };
                bool isValid = Validator.TryValidateProperty(intUserInput, validationContext, validationResults);

                if(isValid)
                {
                    // check for duplicates
                    newFlight.FlightNumber = intUserInput;
                    bool hasDuplicateFlight = DataManager.GetInstance().HasDuplicateFlight(newFlight);
                    if(hasDuplicateFlight == false)
                    {
                        // Flight is valid
                    }
                    else
                    {
                        Console.WriteLine("Flight " + newFlight.GetFlightDesignator() + "already exists.");
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