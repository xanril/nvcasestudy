using CaseStudy.DataManagers;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Screens.Booking
{
    class SearchPNRScreen : IScreen
    {
        private const string KEY_BACK_TO_MENU = "X";
        private Reservation tempReservation;

        public SearchPNRScreen()
        {
            tempReservation = ReservationDataManager.Instance.CreateReservation();
        }

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
  
            if (ValidationHelper.IsFirstCharacterLetter(userInput) == false)
            {
                Console.WriteLine("First character should always be a letter.");
                return;
            }

            ValidationHelperResult validationResult = null;
            validationResult = ValidationHelper.ValidateProperty<Reservation>(tempReservation, nameof(tempReservation.PNR), userInput);
            if(validationResult.HasError)
            {
                Console.Write(validationResult.GetErrorMessages());
                return;
            }

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
