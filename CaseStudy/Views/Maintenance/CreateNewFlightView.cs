using CaseStudy.Abstracts;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Screens.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CaseStudy.Screens.Maintenance.CreateNewFlightScreen;

namespace CaseStudy.Views.Maintenance
{
    class CreateNewFlightView : AbstractView
    {
        private CreateNewFlightScreen presenter;

        public CreateNewFlightView(CreateNewFlightScreen presenter)
        {
            this.presenter = presenter;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > ADD FLIGHT");
        }

        public override void ReadInput(string userInput)
        {
            userInput = userInput.ToUpper();
            userInput = userInput.Trim();

            this.presenter.ProcessInput(userInput);
        }
    }
}
