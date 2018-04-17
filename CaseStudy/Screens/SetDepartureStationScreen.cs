using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class SetDepartureStationScreen : IScreen
    {
        private static readonly string KEY_BACK_TO_MENU = "X";
        private Flight flight;

        public SetDepartureStationScreen(Flight flight)
        {
            this.flight = flight;
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT > SET DEPARTURE STATION");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Destination Station or '" + KEY_BACK_TO_MENU + "' to go back: ");
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

            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(flight, null, null) { MemberName = nameof(flight.DepartureStation) };
            bool isValid = Validator.TryValidateProperty(userInput, validationContext, validationResults);

            if (isValid == false)
            {
                // error validating. Print error messages
                foreach (ValidationResult result in validationResults)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
            else
            {
                bool isDuplicate = (string.Compare(userInput, flight.ArrivalStation) == 0);
                if (isDuplicate)
                {
                    Console.WriteLine("Departure Station should not be the same with Arrival Station.");
                }
                else
                {
                    flight.DepartureStation = userInput;
                    Console.WriteLine("Departure Station is now '" + flight.DepartureStation + "'\n");
                    //ScreenManager.GetInstance().PushScreen(new SetFlightNumberScreen(flight));
                }
            }
        }
    }
}
