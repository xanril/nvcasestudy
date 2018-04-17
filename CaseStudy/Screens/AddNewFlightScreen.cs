using CaseStudy.Models;
using System;

namespace CaseStudy.Screens
{
    class AddNewFlightScreen : IScreen
    {
        private Flight flight;
        private bool isSuccess;

        public AddNewFlightScreen(Flight flight)
        {
            this.flight = flight;
            this.isSuccess = false;
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT > CREATING NEW FLIGHT");

            try
            {
                DataManager.GetInstance().AddFlight(flight);
                isSuccess = true;

                Console.WriteLine("New Flight added.");
                flight.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding new flight.");
                Console.WriteLine(ex.Message);

                isSuccess = false;
            }
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to Main Menu.");
        }

        public void ProcessInput(string userInput)
        {
            // Popup screens until Flight Maintenance Screen
            ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ScreenManager));
        }
    }
}
