using CaseStudy.Abstracts;
using CaseStudy.Screens.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Views.Maintenance
{
    public class FlightMaintenanceView : AbstractView
    {
        private const string MENU_ADD_FLIGHT = "1";
        private const string MENU_SEARCH_FLIGHT = "2";
        private const string MENU_BACK = "3";

        private FlightMaintenanceScreen presenter;

        public FlightMaintenanceView(FlightMaintenanceScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE");
            Console.WriteLine("[" + MENU_ADD_FLIGHT + "] Add Flight");
            Console.WriteLine("[" + MENU_SEARCH_FLIGHT + "] Search Flight");
            Console.WriteLine("[" + MENU_BACK + "] Back to Main Menu");
            Console.WriteLine("");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Select Item: ");
        }

        public override void ReadInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_ADD_FLIGHT:
                    ShowInputFeedback("Add Flight selected.");
                    presenter.MenuSelected(MENU_ADD_FLIGHT);
                    break;

                case MENU_SEARCH_FLIGHT:
                    ShowInputFeedback("Search Flight selected.");
                    presenter.MenuSelected(MENU_SEARCH_FLIGHT);
                    break;

                case MENU_BACK:
                    ShowInputFeedback("Back To Menu selected.");
                    presenter.MenuSelected(MENU_BACK);
                    break;

                default:
                    SetErrorMessage("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
