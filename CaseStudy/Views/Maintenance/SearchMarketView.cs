using CaseStudy.Abstracts;
using CaseStudy.Helpers;
using CaseStudy.Maintenance.Screens;
using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Views.Maintenance
{
    class SearchMarketView : AbstractView
    {
        private SearchMarketScreen presenter;
        private Flight model;
        public SearchMarketView(SearchMarketScreen presenter, Flight model)
        {
            this.model = model;
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY ORIGIN / DESTINATION");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Enter Origin / Destination Code: ");
        }

        public override void ReadInput(string userInput)
        {
            userInput = userInput.ToUpper();
            ValidationHelperResult validationResult = null;

            validationResult = ValidationHelper.ValidateProperty<Flight>(model, nameof(model.DepartureStation), userInput);
            if (validationResult.HasError)
            {
                SetErrorMessage(validationResult.GetErrorMessages());
                return;
            }

            this.presenter.SearchFlightsByStationCode(userInput);
        }

        public void ShowSearchResults(IEnumerable<Flight> resultFlights)
        {
            if (resultFlights == null || resultFlights.Count<Flight>() == 0)
            {
                ShowInputFeedback("No flight record found.");
            }
            else
            {
                Console.WriteLine("Flight record/s found.");
                Console.WriteLine("---------------------------------------------------");
                foreach (Flight flight in resultFlights)
                {
                    Console.WriteLine(flight.ToString());
                }
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}
