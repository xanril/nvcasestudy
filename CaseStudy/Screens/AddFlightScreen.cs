using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class AddFlightScreen : IScreen
    {
        private Flight newFlight;

        public AddFlightScreen()
        {
            int nextFlightID = DataManager.GetInstance().GetNextAvailableFlightID();
            newFlight = new Flight(nextFlightID);
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT");
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

            if(string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Airline Code cannot be empty.");
                return;
            }
        }
    }
}
