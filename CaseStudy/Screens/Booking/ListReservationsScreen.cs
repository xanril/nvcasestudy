using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using CaseStudy.Views.Booking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.Screens.Booking
{
    class ListReservationsScreen : AbstractPresenter
    {
        public ListReservationsScreen()
        {
            IEnumerable<Reservation> reservations = ReservationDataManager.Instance.GetReservations();
            this.view = new ListReservationsView(this, reservations);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }
        
        public void ProcessInput(string userInput)
        {
            ScreenManager.GetInstance().SetActivePresenter(new ReservationsScreen());
        }
    }
}
