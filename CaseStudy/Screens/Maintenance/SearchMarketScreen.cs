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
    class SearchMarketScreen : AbstractPresenter
    {
        private Flight tempFlight;

        public SearchMarketScreen()
        {
            this.tempFlight = FlightDataManager.Instance.CreateFlight();
            this.view = new SearchMarketView(this, tempFlight);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY ORIGIN / DESTINATION");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Enter Origin / Destination Code: ");
        }

        public void SearchFlightsByStationCode(string stationCode)
        {
            IEnumerable<Flight> resultFlights = FlightDataManager.Instance.FindFlightsWithStation(stationCode);
            SearchMarketView actualView = (SearchMarketView)this.view;
            actualView.ShowSearchResults(resultFlights);

            ScreenManager.GetInstance().SetActivePresenter(new SearchFlightScreen());
        }
        
    }
}
