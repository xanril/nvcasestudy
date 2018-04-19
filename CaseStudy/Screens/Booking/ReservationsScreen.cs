using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using CaseStudy.Views.Booking;
using System;

namespace CaseStudy.Screens.Booking
{
    class ReservationsScreen : AbstractPresenter
    {
        private const string MENU_BOOK_FLIGHT = "1";
        private const string MENU_LIST_RESERVATIONS = "2";
        private const string MENU_SEARCH_PNR = "3";
        private const string MENU_BACK = "4";

        public ReservationsScreen()
        {
            this.view = new ReservationView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void ProcessInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_BOOK_FLIGHT:
                    this.view.ShowInputFeedback("Book a Flight selected.");
                    Reservation reservation = ReservationDataManager.Instance.CreateReservation();
                    ScreenManager.GetInstance().PushScreen(new SelectFlightScreen(reservation));
                    break;

                case MENU_LIST_RESERVATIONS:
                    this.view.ShowInputFeedback("List All Reservations selected.");
                    ScreenManager.GetInstance().SetActivePresenter(new ListReservationsScreen());
                    break;

                case MENU_SEARCH_PNR:
                    this.view.ShowInputFeedback("Search By PNR selected.");
                    ScreenManager.GetInstance().SetActivePresenter(new SearchPNRScreen());
                    break;

                case MENU_BACK:
                    this.view.ShowInputFeedback("Back To Menu selected.\n");
                    ScreenManager.GetInstance().SetActivePresenter(new MenuScreen());
                    break;

                default:
                    this.view.SetErrorMessage("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
