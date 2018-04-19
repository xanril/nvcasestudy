using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using CaseStudy.Views.Maintenance;
using System;
using System.Collections.Generic;

namespace CaseStudy.Screens.Maintenance
{
    class SearchFlightNumberScreen : AbstractPresenter
    {
        public SearchFlightNumberScreen()
        {
            this.view = new SearchFlightNumberView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void SearchFlightsByFlightNumber(int flightNumber)
        {
            IEnumerable<Flight> resultFlights = FlightDataManager.Instance.FindFlightsByFlightNumber(flightNumber);
            SearchFlightNumberView actualView = (SearchFlightNumberView)this.view;
            actualView.ShowSearchResults(resultFlights);

            ScreenManager.GetInstance().SetActivePresenter(new SearchFlightScreen());
        }
    }
}
