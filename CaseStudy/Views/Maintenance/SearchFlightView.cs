using CaseStudy.Abstracts;
using CaseStudy.Screens.Maintenance;
using System;

namespace CaseStudy.Views.Maintenance
{
    class SearchFlightView : AbstractView
    {
        private const string MENU_SEARCH_BY_FLIGHT_NUMBER = "1";
        private const string MENU_SEARCH_BY_AIRLINE_CODE = "2";
        private const string MENU_SEARCH_BY_MARKET = "3";
        private const string MENU_BACK_TO_MENU = "4";

        private SearchFlightScreen presenter;

        public SearchFlightView(SearchFlightScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT");
            Console.WriteLine("[" + MENU_SEARCH_BY_FLIGHT_NUMBER + "] By Flight Number");
            Console.WriteLine("[" + MENU_SEARCH_BY_AIRLINE_CODE + "] Airline Code");
            Console.WriteLine("[" + MENU_SEARCH_BY_MARKET + "] By Origin / Destination");
            Console.WriteLine("[" + MENU_BACK_TO_MENU + "] Back to Menu");
        }

        public override void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Select Item: ");
        }

        public override void ReadInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_SEARCH_BY_FLIGHT_NUMBER:
                    ShowInputFeedback("Search By Flight Number selected.");
                    presenter.MenuSelected(MENU_SEARCH_BY_FLIGHT_NUMBER);
                    break;

                case MENU_SEARCH_BY_AIRLINE_CODE:
                    ShowInputFeedback("Search By Airline Code selected.");
                    presenter.MenuSelected(MENU_SEARCH_BY_AIRLINE_CODE);
                    break;

                case MENU_SEARCH_BY_MARKET:
                    ShowInputFeedback("Search By Origin / Destination selected.");
                    presenter.MenuSelected(MENU_SEARCH_BY_MARKET);
                    break;

                case MENU_BACK_TO_MENU:
                    ShowInputFeedback("Back To Menu selected.");
                    presenter.MenuSelected(MENU_BACK_TO_MENU);
                    break;

                default:
                    SetErrorMessage("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
