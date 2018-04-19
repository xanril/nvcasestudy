using CaseStudy.Models;
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

        private const string TEMP_AIRLINE_CODE = "NV";
        private const string FILENAME = "FlightData.json";
        private List<Flight> flights;

        private FlightDataManager()
        {
            flights = new List<Flight>();
        }

        public void LoadData()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);
            FileInfo fileInfo = new FileInfo(filepath);
            if(fileInfo.Exists == false)
            {
                // Create blank file
                using (StreamWriter streamWriter = new StreamWriter(filepath, false))
                {
                    streamWriter.Write("");
                }
            }

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                string fileContents = streamReader.ReadToEnd();
                List<Flight> resultFlights = JsonConvert.DeserializeObject<List<Flight>>(fileContents);

                if (resultFlights != null)
                    this.flights = resultFlights;
            }
        }

        private void SaveData()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);
            using (StreamWriter sw = new StreamWriter(filepath, false))
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
            flight.AirlineCode = TEMP_AIRLINE_CODE;
            flight.FlightNumber = 100;
            flight.DepartureStation = "MNL";
            flight.ArrivalStation = "MLL";
            this.flights.Add(flight);

            flight = new Flight();
            flight.AirlineCode = TEMP_AIRLINE_CODE;
            flight.FlightNumber = 101;
            flight.DepartureStation = "MNL";
            flight.ArrivalStation = "MLS";
            this.flights.Add(flight);

            flight = new Flight();
            flight.AirlineCode = TEMP_AIRLINE_CODE;
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

        public IEnumerable<Flight> FindFlightsByAirlineCode(string airlineCode)
        {
            List<Flight> resultFlights = flights.FindAll(m => m.AirlineCode == airlineCode);
            return resultFlights.ToArray();
        }

        public IEnumerable<Flight> FindFlightsByFlightNumber(int flightNumber)
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
