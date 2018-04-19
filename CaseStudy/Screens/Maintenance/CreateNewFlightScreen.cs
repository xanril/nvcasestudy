using CaseStudy.Abstracts;
using CaseStudy.DataManagers;
using CaseStudy.Helpers;
using CaseStudy.Models;
using CaseStudy.Views.Maintenance;
using System;

namespace CaseStudy.Screens.Maintenance
{
    class CreateNewFlightScreen : AbstractPresenter
    {
        private enum CreateFlightStates
        {
            StateGetAirlineCode = 0,
            StateGetFlightNumber,
            StateGetDepartureStation,
            StateGetArrivalStation,
            StateSaveFlight
        }

        private Flight flight;
        private CreateFlightStates currState;

        public CreateNewFlightScreen()
        {
            this.flight = FlightDataManager.Instance.CreateFlight();
            this.view = new CreateNewFlightView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);

            ChangeState(CreateFlightStates.StateGetAirlineCode);
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > ADD FLIGHT");
        }

        private void ChangeState(CreateFlightStates newState)
        {
            currState = newState;
            switch(currState)
            {
                case CreateFlightStates.StateGetAirlineCode:
                    this.view.SetInputPrompt("Airline Code: ");
                    break;

                case CreateFlightStates.StateGetFlightNumber:
                    this.view.SetInputPrompt("Flight Number: ");
                    break;

                case CreateFlightStates.StateGetDepartureStation:
                    this.view.SetInputPrompt("Departure Station: ");
                    break;

                case CreateFlightStates.StateGetArrivalStation:
                    this.view.SetInputPrompt("Arrival Station: ");
                    break;
            }
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();
            userInput = userInput.Trim();

            ValidationHelperResult validationResult = null;

            switch (currState)
            {
                case CreateFlightStates.StateGetAirlineCode:

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.AirlineCode), userInput);
                    if (validationResult.HasError)
                        this.view.SetErrorMessage(validationResult.GetErrorMessages());
                    else
                    {
                        flight.AirlineCode = userInput;
                        ChangeState(CreateFlightStates.StateGetFlightNumber);
                    }
                    break;

                case CreateFlightStates.StateGetFlightNumber:

                    // convert to int
                    int intUserInput = -1;
                    if(int.TryParse(userInput, out intUserInput) == false)
                    {
                        this.view.SetErrorMessage("Flight Number should only contain numerical characters.");
                        break;
                    }

                    // check for duplicate flight
                    Flight duplicateFlight = FlightDataManager.Instance.FindFlight(flight.AirlineCode, intUserInput);
                    if (duplicateFlight != null)
                    {
                        this.view.SetErrorMessage("Flight already exists. Please try again.");
                        ScreenManager.GetInstance().PopScreen();
                        break;
                    }

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.FlightNumber), intUserInput);
                    if (validationResult.HasError)
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    {
                        flight.FlightNumber = intUserInput;
                        ChangeState(CreateFlightStates.StateGetDepartureStation);
                    }
                   
                    break;

                case CreateFlightStates.StateGetDepartureStation:

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.DepartureStation), userInput);
                    if (validationResult.HasError)
                        this.view.SetErrorMessage(validationResult.GetErrorMessages());
                    else
                    {
                        flight.DepartureStation = userInput;
                        ChangeState(CreateFlightStates.StateGetArrivalStation);
                    }
                    
                    break;

                case CreateFlightStates.StateGetArrivalStation:

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.ArrivalStation), userInput);
                    if (validationResult.HasError)
                        this.view.SetErrorMessage(validationResult.GetErrorMessages());
                    else
                    {
                        flight.ArrivalStation = userInput;
                        ScreenManager.GetInstance().SetActivePresenter(new ConfirmNewFlightScreen(flight));
                    }

                    break;
            }
        }
    }
}
