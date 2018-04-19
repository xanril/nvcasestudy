using CaseStudy.Abstracts;
using CaseStudy.Screens.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Views.Booking
{
    class ReservationView : AbstractView
    {
        private const string MENU_BOOK_FLIGHT = "1";
        private const string MENU_LIST_RESERVATIONS = "2";
        private const string MENU_SEARCH_PNR = "3";
        private const string MENU_BACK = "4";

        private ReservationsScreen presenter;

        public ReservationView(ReservationsScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nRESERVATIONS");
            Console.WriteLine("[" + MENU_BOOK_FLIGHT + "] Book a Flight");
            Console.WriteLine("[" + MENU_LIST_RESERVATIONS + "] List All Reservations");
            Console.WriteLine("[" + MENU_SEARCH_PNR + "] Search By PNR");
            Console.WriteLine("[" + MENU_BACK + "] Back to Main Menu");
            Console.WriteLine("");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Select Item: ");
        }

        public override void ReadInput(string userInput)
        {
            this.presenter.ProcessInput(userInput);
        }
    }
}
