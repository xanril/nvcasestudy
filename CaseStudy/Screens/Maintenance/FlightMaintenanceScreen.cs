using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Maintenance.Screens
{
    class FlightMaintenanceScreen : IScreen
    {
        private const string MENU_ADD_FLIGHT = "1";
        private const string MENU_SEARCH_FLIGHT = "2";
        private const string MENU_BACK = "3";

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE");
            Console.WriteLine("[" + MENU_ADD_FLIGHT + "] Add Flight");
            Console.WriteLine("[" + MENU_SEARCH_FLIGHT + "] Search Flight");
            Console.WriteLine("[" + MENU_BACK + "] Back to Main Menu");
            Console.WriteLine("");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Select Item: ");
        }

        public void ProcessInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_ADD_FLIGHT:
                    Console.WriteLine("Add Flight selected.");
                    Flight newFlight = DataManager.GetInstance().CreateFlight();
                    ScreenManager.GetInstance().PushScreen(new SetNewFlightScreen(newFlight));
                    break;

                case MENU_SEARCH_FLIGHT:
                    Console.WriteLine("Search Flight selected.");
                    ScreenManager.GetInstance().PushScreen(new SearchFlightScreen());
                    break;

                case MENU_BACK:
                    Console.WriteLine("Back To Menu selected.");
                    ScreenManager.GetInstance().PopScreen();
                    break;

                default:
                    Console.WriteLine("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
