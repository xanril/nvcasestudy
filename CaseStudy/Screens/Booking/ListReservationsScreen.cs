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
            Console.WriteLine("\nRESERVATIONS > LIST RESERVATIONS");
            Console.WriteLine("");

            if (this.reservations.Count<Reservation>() == 0)
            {
                Console.WriteLine("No Reservation records found.\n");
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

        public void ShowInputPrompt()
        {
            Console.Write("Press any key to continue.");
        }

        public void ProcessInput(string userInput)
        {
            ScreenManager.GetInstance().PopScreen();
        }
    }
}
