using CaseStudy.Abstracts;
using CaseStudy.Models;
using CaseStudy.Screens.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Views.Maintenance
{
    class ConfirmNewFlightView : AbstractView
    {
        private const string KEY_CONFIRM = "Y";
        private const string KEY_CANCEL = "N";
        private ConfirmNewFlightScreen presenter;
        private Flight model;

        public ConfirmNewFlightView(ConfirmNewFlightScreen presenter, Flight model)
        {
            this.presenter = presenter;
            this.model = model;
        }

        public override void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > NEW FLIGHT SUMMARY");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(model.ToString());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
        }

        public override void ShowInputPrompt()
        {
            Console.Write("Confirm adding this flight? (Y/N): ");
        }

        public override void ReadInput(string userInput)
        {
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case KEY_CONFIRM:

                    try
                    {
                        ShowInputFeedback("Flight saved.");
                        presenter.AddFlight();
                    }
                    catch (Exception ex)
                    {
                        SetErrorMessage(ex.Message);
                    }
                    break;

                case KEY_CANCEL:

                    ShowInputFeedback("New flight cancelled.");
                    presenter.ChangeBackToMenu();
                    break;

                default:

                    SetErrorMessage("Cannot recognize input. Please try again.");
                    break;
            }
        }
    }
}
