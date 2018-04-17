using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class FlightMaintenanceScreen : IScreen
    {
        private const string MENU_ADD_FLIGHT = "1";
        private const string MENU_SEARCH_FLIGHT = "2";
        private const string MENU_BACK = "3";

        public void Display()
        {
            Console.WriteLine("FLIGHT MAINTENANCE");
            Console.WriteLine("[" + MENU_ADD_FLIGHT + "] Add Flight");
            Console.WriteLine("[" + MENU_SEARCH_FLIGHT + "] Search Flight");
            Console.WriteLine("[" + MENU_BACK + "] Back to Main Menu");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Select Item: ");
        }

        public void ProcessInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_ADD_FLIGHT:
                    Console.WriteLine("Add Flight selected.\n");
                    Flight newFlight = DataManager.GetInstance().CreateFlight();
                    ScreenManager.GetInstance().PushScreen(new SetAirlineCodeScreen(newFlight));
                    break;

                case MENU_SEARCH_FLIGHT:
                    Console.WriteLine("Search Flight selected.\n");
                    ScreenManager.GetInstance().PushScreen(new SearchFlightScreen());
                    break;

                case MENU_BACK:
                    Console.WriteLine("Back To Menu selected.\n");
                    ScreenManager.GetInstance().PopScreen();
                    break;

                default:
                    Console.WriteLine("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
