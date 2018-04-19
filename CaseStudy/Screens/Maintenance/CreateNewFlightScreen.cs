using CaseStudy.DataManagers;
using CaseStudy.Helpers;
using CaseStudy.Models;
using System;

namespace CaseStudy.Screens.Maintenance
{
    class CreateNewFlightScreen : IScreen
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

        public CreateNewFlightScreen(Flight flight)
        {
            this.flight = flight;
            currState = CreateFlightStates.StateGetAirlineCode;
        }

        public void Display()
        {
            Console.WriteLine("\nFLIGHT MAINTENANCE > ADD FLIGHT");
        }

        public void ShowInputPrompt()
        {
            switch(currState)
            {
                case CreateFlightStates.StateGetAirlineCode:
                    Console.Write("Airline Code: ");
                    break;

                case CreateFlightStates.StateGetFlightNumber:
                    Console.Write("Flight Number: ");
                    break;

                case CreateFlightStates.StateGetDepartureStation:
                    Console.Write("Departure Station: ");
                    break;

                case CreateFlightStates.StateGetArrivalStation:
                    Console.Write("Arrival Station: ");
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
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    {
                        flight.AirlineCode = userInput;
                        currState = CreateFlightStates.StateGetFlightNumber;
                    }
                    break;

                case CreateFlightStates.StateGetFlightNumber:

                    // convert to int
                    int intUserInput = -1;
                    if(int.TryParse(userInput, out intUserInput) == false)
                    {
                        Console.WriteLine("Flight Number should only contain numerical characters.");
                        break;
                    }

                    // check for duplicate flight
                    Flight duplicateFlight = FlightDataManager.Instance.FindFlight(flight.AirlineCode, intUserInput);
                    if (duplicateFlight != null)
                    {
                        Console.WriteLine("Flight already exists. Please try again.");
                        ScreenManager.GetInstance().PopScreen();
                        break;
                    }

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.FlightNumber), intUserInput);
                    if (validationResult.HasError)
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    {
                        flight.FlightNumber = intUserInput;
                        currState = CreateFlightStates.StateGetDepartureStation;
                    }
                   
                    break;

                case CreateFlightStates.StateGetDepartureStation:

                    // check for same flight with same departure station
                    //Flight sameFlight = FlightDataManager.Instance.FindFlight(flight.AirlineCode, flight.FlightNumber);
                    //if(sameFlight != null && sameFlight.DepartureStation.Equals(userInput))
                    //{
                    //    Console.WriteLine("Flight with same departure station already exists.");
                    //    break;
                    //}

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.DepartureStation), userInput);
                    if (validationResult.HasError)
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    {
                        flight.DepartureStation = userInput;
                        currState = CreateFlightStates.StateGetArrivalStation;
                    }
                    
                    break;

                case CreateFlightStates.StateGetArrivalStation:

                    validationResult = ValidationHelper.ValidateProperty<Flight>(flight, nameof(flight.ArrivalStation), userInput);
                    if (validationResult.HasError)
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    {
                        flight.ArrivalStation = userInput;
                        ScreenManager.GetInstance().PushScreen(new ConfirmNewFlightScreen(flight));
                    }

                    break;
            }
        }
    }
}
