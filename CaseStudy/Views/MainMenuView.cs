using CaseStudy.Abstracts;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Views
{
    public class MainMenuView : AbstractView
    {
        private const string MENU_FLIGHT_MAINTENANCE = "1";
        private const string MENU_RESERVATION = "2";
        private const string MENU_EXIT = "3";

        private MenuScreen presenter;

        public MainMenuView(MenuScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nMAIN MENU:");
            Console.WriteLine("[" + MENU_FLIGHT_MAINTENANCE + "] Go to Flight Maintenance Screen");
            Console.WriteLine("[" + MENU_RESERVATION + "] Go to Reservation Screen");
            Console.WriteLine("[" + MENU_EXIT + "] Exit");
            Console.WriteLine("");
        }

        public override void ShowInputPrompt()
        {
            base.ShowInputPrompt();
            Console.Write("Select Item: ");
        }

        public override void ReadInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_FLIGHT_MAINTENANCE:
                    ShowInputFeedback("Flight Maintenance Selected.");
                    presenter.MenuSelected(MENU_FLIGHT_MAINTENANCE);
                    break;

                case MENU_RESERVATION:
                    ShowInputFeedback("Reservations Selected.");
                    presenter.MenuSelected(MENU_RESERVATION);
                    break;

                case MENU_EXIT:
                    ShowInputFeedback("Exit Selected.");
                    presenter.MenuSelected(MENU_EXIT);
                    break;

                default:
                    SetErrorMessage("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
