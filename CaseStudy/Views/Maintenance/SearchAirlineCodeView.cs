using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
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
    class SearchAirlineCodeView : AbstractView
    {
        private SearchAirlineCodeScreen presenter;
        private Flight model;

        public SearchAirlineCodeView(SearchAirlineCodeScreen presenter, Flight model)
        {
            this.presenter = presenter;
            this.model = model;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY AIRLINE CODE");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Airline Code: ");
        }

        public override void ReadInput(string userInput)
        {
            userInput = userInput.ToUpper();

            ValidationHelperResult validationResult = null;
            validationResult = ValidationHelper.ValidateProperty<Flight>(this.model, nameof(this.model.AirlineCode), userInput);
            if (validationResult.HasError)
            {
                SetErrorMessage(validationResult.GetErrorMessages());
                return;
            }

            this.presenter.SearchFlightsByAirlineCode(userInput);
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
