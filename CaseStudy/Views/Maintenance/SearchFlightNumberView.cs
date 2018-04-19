using CaseStudy.Abstracts;
using CaseStudy.Models;
using CaseStudy.Screens;
using CaseStudy.Screens.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.Views.Maintenance
{
    class SearchFlightNumberView : AbstractView
    {
        private SearchFlightNumberScreen presenter;

        public SearchFlightNumberView(SearchFlightNumberScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > SEARCH FLIGHT > BY FLIGHT NUMBER");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Flight Number: ");
        }

        public override void ReadInput(string userInput)
        {
            int parsedFlightNumber = -1;

            if (int.TryParse(userInput, out parsedFlightNumber))
            {
                this.presenter.SearchFlightsByFlightNumber(parsedFlightNumber);
            }
            else
            {
                SetErrorMessage("Flight Numbers should only be numeric.");
            }
        }

        public void ShowSearchResults(IEnumerable<Flight> flights)
        {
            if (flights == null || flights.Count<Flight>() == 0)
            {
                ShowInputFeedback("No flight record found.");
            }
            else
            {
                Console.WriteLine("Flight record/s found.");
                Console.WriteLine("---------------------------------------------------");
                foreach (Flight flight in flights)
                {
                    Console.WriteLine(flight.ToString());
                }
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}
