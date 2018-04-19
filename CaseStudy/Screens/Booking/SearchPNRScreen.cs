using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Screens.Booking
{
    class SearchPNRScreen : IScreen
    {
        private const string KEY_BACK_TO_MENU = "X";

        public void Display()
        {
            Console.WriteLine("\nRESERVATIONS > SEARCH BY PNR");
        }

        public void ShowInputPrompt()
        {
            Console.Write("PNR: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();

            Reservation reservation = ReservationDataManager.Instance.FindReservation(userInput);
            
            if(reservation == null)
            {
                Console.WriteLine("No Reservation record exists for PNR {0}.", userInput);
                ScreenManager.GetInstance().PopScreen();
            }
            else
            {
                Console.WriteLine("Reservation record found.");
                Console.WriteLine("---------------------------------------------------");
                Console.Write(reservation.ToString());
                Console.WriteLine("---------------------------------------------------");

                ScreenManager.GetInstance().PopScreen();
            }
        }
    }
}
