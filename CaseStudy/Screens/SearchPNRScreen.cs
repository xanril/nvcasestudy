using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class SearchPNRScreen : IScreen
    {
        private const string KEY_BACK_TO_MENU = "X";

        public void Display()
        {
            Console.WriteLine("RESERVATIONS > LIST RESERVATIONS");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter PNR or press 'X' to go back to menu: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();

            if(userInput == KEY_BACK_TO_MENU)
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                return;
            }

            userInput = userInput.ToLower();
            Reservation reservation = DataManager.GetInstance().FindReservation(userInput);
            
            if(reservation == null)
            {
                Console.WriteLine("No Reservation record exists for PNR " + userInput);
            }
            else
            {
                Console.WriteLine("Reservation record found.");
                Console.WriteLine(reservation.GetInfo());
            }
        }
    }
}
