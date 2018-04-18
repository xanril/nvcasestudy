using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.Booking.Screens
{
    class ListReservationsScreen : IScreen
    {
        private IEnumerable<Reservation> reservations;

        public ListReservationsScreen(IEnumerable<Reservation> reservations)
        {
            this.reservations = reservations;
        }

        public void Display()
        {
            Console.WriteLine("RESERVATIONS > LIST RESERVATIONS");
            Console.WriteLine("");

            if (this.reservations.Count<Reservation>() == 0)
            {
                Console.WriteLine("No Reservation records found.\n");
            }
            else
            {
                foreach(Reservation reservation in reservations)
                {
                    Console.WriteLine(reservation.GetInfo());
                }
            }
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("Press any key to continue.");
        }

        public void ProcessInput(string userInput)
        {
            ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
        }
    }
}
