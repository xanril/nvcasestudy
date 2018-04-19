using CaseStudy.Helpers;
using CaseStudy.Models;
using System;

namespace CaseStudy.Screens.Booking
{
    public class SetFlightDateScreen : IScreen
    {
        private Reservation reservation;

        public SetFlightDateScreen(Reservation reservation)
        {
            this.reservation = reservation;
        }

        public void Display()
        {
            Console.WriteLine("\nRESERVATIONS > SET FLIGHT DATE");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Flight Date (MM/DD/YYYY): ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            DateTime flightDate = DateTime.Now;

            if (DateTime.TryParse(userInput, out flightDate))
            {
                if (ValidationHelper.IsFutureDate(flightDate) == false)
                    Console.WriteLine("Flight Date should be a future date.");
                else
                {
                    reservation.FlightDate = flightDate;
                    ScreenManager.GetInstance().PushScreen(new SetFlightPassengersScreen(reservation));
                }
            }
            else
            {
                Console.WriteLine("Cannot recognize Date Format. Please try again.");
            }
        }
    }
}
