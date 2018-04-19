﻿using CaseStudy.DataManagers;
using CaseStudy.Models;
using System;

namespace CaseStudy.Screens.Maintenance
{
    class SetNewFlightScreen : IScreen
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

        public SetNewFlightScreen(Flight flight)
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

            switch(currState)
            {
                case CreateFlightStates.StateGetAirlineCode:
                    try
                    {
                        flight.AirlineCode = userInput;
                        currState = CreateFlightStates.StateGetFlightNumber;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
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

                    try
                    {
                        flight.FlightNumber = intUserInput;
                        currState = CreateFlightStates.StateGetDepartureStation;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
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

                    try
                    {
                        flight.DepartureStation = userInput;
                        currState = CreateFlightStates.StateGetArrivalStation;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                    break;

                case CreateFlightStates.StateGetArrivalStation:

                    try
                    {
                        flight.ArrivalStation = userInput;
                        ScreenManager.GetInstance().PushScreen(new ConfirmNewFlightScreen(flight));
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        break;
                    }

                    break;
            }
        }
    }
}
