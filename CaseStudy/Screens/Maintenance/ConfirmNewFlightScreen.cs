using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Maintenance.Screens;
using CaseStudy.Models;
using CaseStudy.Views.Maintenance;
using System;

namespace CaseStudy.Screens.Maintenance
{
    public class ConfirmNewFlightScreen : AbstractPresenter
    {
        private const string KEY_CONFIRM = "Y";
        private const string KEY_CANCEL = "N";
        private Flight flight;

        public ConfirmNewFlightScreen(Flight flight)
        {
            this.flight = flight;
            this.view = new ConfirmNewFlightView(this, flight);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void AddFlight()
        {
            FlightDataManager.Instance.AddFlight(flight);
            ScreenManager.GetInstance().SetActivePresenter(new FlightMaintenanceScreen());
        }

        public void ChangeBackToMenu()
        {
            ScreenManager.GetInstance().SetActivePresenter(new FlightMaintenanceScreen());
        }
    }
}
