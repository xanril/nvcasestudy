using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Maintenance.Screens
{
    class AddNewFlightScreen : IScreen
    {
        private Flight flight;

        public AddNewFlightScreen(Flight flight)
        {
            this.flight = flight;
        }

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE > ADD FLIGHT > CREATING NEW FLIGHT");

            try
            {
                DataManager.GetInstance().AddFlight(flight);

                Console.WriteLine("New Flight added.");
                Console.WriteLine(flight.GetInfo());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding new flight. Please try again.");
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to Main Menu.");
        }

        public void ProcessInput(string userInput)
        {
            ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(FlightMaintenanceScreen));
        }
    }
}
