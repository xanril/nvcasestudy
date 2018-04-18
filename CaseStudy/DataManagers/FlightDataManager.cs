using CaseStudy.Models;
using System;
using System.Collections.Generic;

namespace CaseStudy.DataManagers
{
    public class FlightDataManager
    {
        private static FlightDataManager instance;
        public static FlightDataManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new FlightDataManager();

                return instance;
            }
        }

        private const string AIRLINE_CODE = "NV";
        private List<Flight> flights;

        private FlightDataManager()
        {
            flights = new List<Flight>();
        }

        public void LoadData()
        {
            CreateDummyFlights();
        }

        private void CreateDummyFlights()
        {
            Flight flight = new Flight();
            flight.AirlineCode = AIRLINE_CODE;
            flight.FlightNumber = 100;
            flight.DepartureStation = "MNL";
            flight.ArrivalStation = "MLL";
            this.flights.Add(flight);

            flight = new Flight();
            flight.AirlineCode = AIRLINE_CODE;
            flight.FlightNumber = 101;
            flight.DepartureStation = "MNL";
            flight.ArrivalStation = "MLS";
            this.flights.Add(flight);

            flight = new Flight();
            flight.AirlineCode = AIRLINE_CODE;
            flight.FlightNumber = 102;
            flight.DepartureStation = "MNL";
            flight.ArrivalStation = "MLU";
            this.flights.Add(flight);
        }

        public bool HasDuplicateFlight(Flight flight)
        {
            Flight dupFlight = this.flights.Find(m => m.AirlineCode == flight.AirlineCode
                                                    && m.FlightNumber == flight.FlightNumber);
            if (dupFlight != null)
                return true;

            return false;
        }

        public Flight CreateFlight()
        {
            Flight newFlight = new Flight();
            return newFlight;
        }

        public void AddFlight(Flight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException("Flight to be added cannot be null.");
            }

            this.flights.Add(flight);
        }

        public Flight FindFlight(string airlinecode, int flightNumber)
        {
            Flight flight = null;
            flight = flights.Find(m => m.AirlineCode.Equals(airlinecode) && m.FlightNumber == flightNumber);

            return flight;
        }

        public Flight[] FindFlightsByAirlineCode(string airlineCode)
        {
            List<Flight> resultFlights = flights.FindAll(m => m.AirlineCode == airlineCode);
            return resultFlights.ToArray();
        }

        public Flight[] FindFlightsByFlightNumber(int flightNumber)
        {
            List<Flight> resultFlights = flights.FindAll(m => m.FlightNumber == flightNumber);
            return resultFlights.ToArray();
        }

        public Flight[] FindFlightsWithStation(string stationCode)
        {
            List<Flight> resultFlights = flights.FindAll(m => m.DepartureStation == stationCode || m.ArrivalStation == stationCode);
            return resultFlights.ToArray();
        }
    }
}
