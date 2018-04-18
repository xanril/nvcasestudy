using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Booking.Screens
{
    class ReservationsScreen : IScreen
    {
        private const string MENU_BOOK_FLIGHT = "1";
        private const string MENU_LIST_RESERVATIONS = "2";
        private const string MENU_SEARCH_PNR = "3";
        private const string MENU_BACK = "4";

        public void Display()
        {
            Console.WriteLine("\nRESERVATIONS");
            Console.WriteLine("[" + MENU_BOOK_FLIGHT + "] Book a Flight");
            Console.WriteLine("[" + MENU_LIST_RESERVATIONS + "] List All Reservations");
            Console.WriteLine("[" + MENU_SEARCH_PNR + "] Search By PNR");
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
                case MENU_BOOK_FLIGHT:
                    Console.WriteLine("Book a Flight selected.");
                    Reservation reservation = DataManager.GetInstance().CreateReservation();
                    ScreenManager.GetInstance().PushScreen(new SelectFlightScreen(reservation));
                    break;

                case MENU_LIST_RESERVATIONS:
                    Console.WriteLine("List All Reservations selected.");
                    ListReservationsScreen listReservationsScreen = new ListReservationsScreen(DataManager.GetInstance().Reservations);
                    ScreenManager.GetInstance().PushScreen(listReservationsScreen);
                    break;

                case MENU_SEARCH_PNR:
                    Console.WriteLine("Search By PNR selected.");
                    ScreenManager.GetInstance().PushScreen(new SearchPNRScreen());
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
