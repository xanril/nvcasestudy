﻿using CaseStudy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
        private const string FILE_SAVE_PATH = "C:\\Users\\kmitra\\Documents";
        private const string FILENAME = "FlightData.json";
        private List<Flight> flights;

        private FlightDataManager()
        {
            flights = new List<Flight>();
        }

        public void LoadData()
        {
            using (StreamReader streamReader = new StreamReader(Path.Combine(FILE_SAVE_PATH, FILENAME)))
            {
                string fileContents = streamReader.ReadToEnd();
                this.flights = JsonConvert.DeserializeObject<List<Flight>>(fileContents);
            }
        }

        private void SaveData()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(FILE_SAVE_PATH, FILENAME), false))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, this.flights);
                }
            }
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

            SaveData();
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
