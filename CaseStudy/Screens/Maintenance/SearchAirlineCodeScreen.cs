using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Screens;
using CaseStudy.Screens.Maintenance;
using CaseStudy.Views.Maintenance;
using System;
using System.Collections.Generic;

namespace CaseStudy.Maintenance.Screens
{
    class SearchAirlineCodeScreen : AbstractPresenter
    {
        public SearchAirlineCodeScreen()
        {
            Flight tempFlight = FlightDataManager.Instance.CreateFlight();
            this.view = new SearchAirlineCodeView(this, tempFlight);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void SearchFlightsByAirlineCode(string airlineCode)
        {
            IEnumerable<Flight> resultFlights = FlightDataManager.Instance.FindFlightsByAirlineCode(airlineCode);
            SearchAirlineCodeView actualView = (SearchAirlineCodeView)this.view;
            actualView.ShowSearchResults(resultFlights);

            ScreenManager.GetInstance().SetActivePresenter(new SearchFlightScreen());
        }
    }
}
