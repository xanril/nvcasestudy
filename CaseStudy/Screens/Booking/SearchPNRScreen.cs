using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Screens;
using CaseStudy.Views.Booking;
using System;

namespace CaseStudy.Screens.Booking
{
    class SearchPNRScreen : AbstractPresenter
    {
        private const string KEY_BACK_TO_MENU = "X";
        private Reservation tempReservation;

        public SearchPNRScreen()
        {
            this.view = new SearchPNRView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);
            tempReservation = ReservationDataManager.Instance.CreateReservation();
        }


        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();
  
            if (ValidationHelper.IsFirstCharacterLetter(userInput) == false)
            {
                this.view.SetErrorMessage("First character should always be a letter.");
                return;
            }

            ValidationHelperResult validationResult = null;
            validationResult = ValidationHelper.ValidateProperty<Reservation>(tempReservation, nameof(tempReservation.PNR), userInput);
            if(validationResult.HasError)
            {
                this.view.SetErrorMessage(validationResult.GetErrorMessages());
                return;
            }

            Reservation reservation = ReservationDataManager.Instance.FindReservation(userInput);
            
            if(reservation == null)
            {
                this.view.ShowInputFeedback(string.Format("No Reservation record exists for PNR {0}.", userInput));
                ScreenManager.GetInstance().SetActivePresenter(new ReservationsScreen());
            }
            else
            {
                SearchPNRView actualView = (SearchPNRView)this.view;
                actualView.ShowPNRInfo(reservation);

                ScreenManager.GetInstance().SetActivePresenter(new ReservationsScreen());
            }
        }
    }
}
