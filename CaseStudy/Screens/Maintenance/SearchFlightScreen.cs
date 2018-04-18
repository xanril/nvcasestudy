using CaseStudy.Maintenance.Screens;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Maintenance.Screens
{
    class SearchFlightScreen : IScreen
    {
        private const string MENU_SEARCH_BY_FLIGHT_NUMBER = "1";
        private const string MENU_SEARCH_BY_AIRLINE_CODE = "2";
        private const string MENU_SEARCH_BY_MARKET = "3";
        private const string MENU_BACK_TO_MENU = "4";

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT");
            Console.WriteLine("[" + MENU_SEARCH_BY_FLIGHT_NUMBER + "] By Flight Number");
            Console.WriteLine("[" + MENU_SEARCH_BY_AIRLINE_CODE + "] Airline Code");
            Console.WriteLine("[" + MENU_SEARCH_BY_MARKET + "] By Origin / Destination");
            Console.WriteLine("[" + MENU_BACK_TO_MENU + "] Back to Menu");
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
                case MENU_SEARCH_BY_FLIGHT_NUMBER:
                    Console.WriteLine("Search By Flight Number selected.");
                    ScreenManager.GetInstance().PushScreen(new SearchFlightNumberScreen());
                    break;

                case MENU_SEARCH_BY_AIRLINE_CODE:
                    Console.WriteLine("Search By Airline Code selected.");
                    ScreenManager.GetInstance().PushScreen(new SearchAirlineCodeScreen());
                    break;

                case MENU_SEARCH_BY_MARKET:
                    Console.WriteLine("Search By Origin / Destination selected.");
                    ScreenManager.GetInstance().PushScreen(new SearchMarketScreen());
                    break;

                case MENU_BACK_TO_MENU:
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
