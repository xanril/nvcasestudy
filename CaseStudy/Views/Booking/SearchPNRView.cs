using CaseStudy.Abstracts;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Screens.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Views.Booking
{
    class SearchPNRView : AbstractView
    {
        private SearchPNRScreen presenter;
        public SearchPNRView(SearchPNRScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nRESERVATIONS > SEARCH BY PNR");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("PNR: ");
        }

        public override void ReadInput(string userInput)
        {
            this.presenter.ProcessInput(userInput);
        }

        public void ShowPNRInfo(Reservation reservation)
        {
            Console.WriteLine("Reservation record found.");
            Console.WriteLine("---------------------------------------------------");
            Console.Write(reservation.ToString());
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
