using CaseStudy.DataManagers;
using CaseStudy.Maintenance.Screens;
using CaseStudy.Models;
using System;

namespace CaseStudy.Screens.Maintenance
{
    public class ConfirmNewFlightScreen : IScreen
    {
        private const string KEY_CONFIRM = "Y";
        private const string KEY_CANCEL = "N";
        private Flight flight;

        public ConfirmNewFlightScreen(Flight flight)
        {
            this.flight = flight;
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > NEW FLIGHT SUMMARY");
            Console.WriteLine("New Flight added.");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(flight.ToString());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Confirm adding this flight? (Y/N): ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case KEY_CONFIRM:

                    try
                    {
                        FlightDataManager.Instance.AddFlight(flight);
                        Console.WriteLine("Flight saved.");
                        ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(FlightMaintenanceScreen));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case KEY_CANCEL:

                    Console.WriteLine("New flight cancelled.");
                    ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(FlightMaintenanceScreen));
                    break;

                default:

                    Console.WriteLine("Cannot recognize input. Please try again.");
                    break;
            }
        }
    }
}
