using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class SelectFlightScreen : IScreen
    {
        private const string KEY_BACK_TO_MENU = "X";
        private Reservation reservation;

        public SelectFlightScreen(Reservation reservation)
        {
            this.reservation = reservation;
        }

        public void Display()
        {
            Console.WriteLine("RESERVATIONS > SELECT FLIGHT");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter Airline Code and Flight Number (XX-XXXX): ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();

            if (userInput == KEY_BACK_TO_MENU)
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                return;
            }

            string[] arrInputs = userInput.Split('-');
            if(arrInputs.Length < 2)
            {
                Console.WriteLine("Invalid Flight Designator format. Please try again.");
                return;
            }

            string airlineCode = arrInputs[0];
            int flightNumber = 0;

            if(int.TryParse(arrInputs[1], out flightNumber))
            {
                Flight flight = DataManager.GetInstance().FindFlight(airlineCode, flightNumber);
                if(flight != null)
                {
                    Console.WriteLine("Flight record found.");
                    flight.PrintInfo();
                    Console.WriteLine("");

                    ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                }
                else
                {
                    Console.WriteLine("Flight record does not exist.");
                    ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                }
            }
            else
            {
                Console.WriteLine("Invalid Flight Designator format. Please try again.");
                return;
            }
        }

        
    }
}
