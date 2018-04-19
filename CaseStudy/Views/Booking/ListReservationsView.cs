using CaseStudy.Abstracts;
using CaseStudy.Models;
using CaseStudy.Screens.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Views.Booking
{
    class ListReservationsView : AbstractView
    {
        private ListReservationsScreen presenter;
        private IEnumerable<Reservation> reservations;

        public ListReservationsView(ListReservationsScreen presenter, IEnumerable<Reservation> reservations)
        {
            this.presenter = presenter;
            this.reservations = reservations;
        }

        public override void Display()
        {
            Console.WriteLine("\nRESERVATIONS > LIST RESERVATIONS");
            Console.WriteLine("");

            if (this.reservations.Count<Reservation>() == 0)
            {
                Console.WriteLine("No Reservation records found.");
            }
            else
            {
                Console.WriteLine("Reservation record/s found.");
                Console.WriteLine("---------------------------------------------------");
                bool hasPassed = false;
                foreach (Reservation reservation in reservations)
                {
                    if (hasPassed)
                    {
                        Console.Write("\n" + reservation.ToString());
                    }
                    else
                    {
                        Console.Write(reservation.ToString());
                        hasPassed = true;
                    }
                }
                Console.WriteLine("---------------------------------------------------");
            }

            Console.WriteLine("");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Press any key to continue.");
        }

        public override void ReadInput(string userInput)
        {
            this.presenter.ProcessInput(userInput);
        }
    }
}
