using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class SetArrivalStationScreen : IScreen
    {
        private static readonly string KEY_BACK_TO_MENU = "X";
        private Flight flight;

        public SetArrivalStationScreen(Flight flight)
        {
            this.flight = flight;
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT > SET ARRIVAL STATION");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Arrival Station or '" + KEY_BACK_TO_MENU + "' to go back: ");
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
            ValidationContext validationContext = new ValidationContext(flight, null, null) { MemberName = nameof(flight.ArrivalStation) };
            bool isValid = Validator.TryValidateProperty(userInput, validationContext, validationResults);

            if (isValid == false)
            {
                foreach (ValidationResult result in validationResults)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
            else
            {
                bool isDuplicate = (string.Compare(userInput, flight.DepartureStation) == 0);
                if (isDuplicate)
                {
                    Console.WriteLine("Arrival Station should not be the same with Destination Station.");
                }
                else
                {
                    flight.ArrivalStation = userInput;
                    Console.WriteLine("Arrival Station is now '" + flight.ArrivalStation + "'\n");
                    ScreenManager.GetInstance().PushScreen(new AddNewFlightScreen(flight));
                }
            }
        }
    }
}
