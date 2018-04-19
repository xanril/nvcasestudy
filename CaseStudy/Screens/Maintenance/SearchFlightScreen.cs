using CaseStudy.Abstracts;
using CaseStudy.Maintenance.Screens;
using CaseStudy.Screens;
using CaseStudy.Views.Maintenance;
using System;

namespace CaseStudy.Screens.Maintenance
{
    class SearchFlightScreen : AbstractPresenter
    {
        private const string MENU_SEARCH_BY_FLIGHT_NUMBER = "1";
        private const string MENU_SEARCH_BY_AIRLINE_CODE = "2";
        private const string MENU_SEARCH_BY_MARKET = "3";
        private const string MENU_BACK_TO_MENU = "4";

        public SearchFlightScreen()
        {
            this.view = new SearchFlightView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void MenuSelected(string userInput)
        {
            switch (userInput)
            {
                case MENU_SEARCH_BY_FLIGHT_NUMBER:
                    ScreenManager.GetInstance().PushScreen(new SearchFlightNumberScreen());
                    break;

                case MENU_SEARCH_BY_AIRLINE_CODE:
                    ScreenManager.GetInstance().PushScreen(new SearchAirlineCodeScreen());
                    break;

                case MENU_SEARCH_BY_MARKET:
                    ScreenManager.GetInstance().PushScreen(new SearchMarketScreen());
                    break;

                case MENU_BACK_TO_MENU:
                    ScreenManager.GetInstance().PopScreen();
                    break;

                default:
                    break;
            }
        }
    }
}
