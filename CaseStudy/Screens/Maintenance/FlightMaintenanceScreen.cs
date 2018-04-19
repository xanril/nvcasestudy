using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Views.Maintenance;
using System;

namespace CaseStudy.Screens.Maintenance
{
    public class FlightMaintenanceScreen : AbstractPresenter
    {
        private const string MENU_ADD_FLIGHT = "1";
        private const string MENU_SEARCH_FLIGHT = "2";
        private const string MENU_BACK = "3";

        public FlightMaintenanceScreen()
        {
            this.view = new FlightMaintenanceView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void MenuSelected(string userInput)
        {
            switch (userInput)
            {
                case MENU_ADD_FLIGHT:
                    ScreenManager.GetInstance().SetActivePresenter(new CreateNewFlightScreen());
                    break;

                case MENU_SEARCH_FLIGHT:
                    ScreenManager.GetInstance().SetActivePresenter(new SearchFlightScreen());
                    break;

                case MENU_BACK:
                    ScreenManager.GetInstance().PopScreen();
                    break;

                default:
                    Console.WriteLine("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
