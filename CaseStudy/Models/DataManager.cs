using System;
using System.Collections.Generic;

namespace CaseStudy.Models
{
    class DataManager
    {
        private static DataManager instance;
        public static DataManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }

            return instance;
        }

        private const string AIRLINE_CODE = "NV";

        private List<Flight> _flights;
        private List<Reservation> _reservations;
        private List<Station> _stations;
        private int _lastFlightID = -1;

        private DataManager()
        {
            _flights = new List<Flight>();
            _reservations = new List<Reservation>();
            _stations = new List<Station>();
            SetStationData();
        }

        public void LoadData()
        {
            CreateDummyFlights();
            CreateDummyReservations();
        }

        private void SetStationData()
        {
            _stations.Add(new Station("MLL", "Marshall Airport"));                       // 0
            _stations.Add(new Station("MLS", "Miles City Municipal Airport"));
            _stations.Add(new Station("MLU", "Monroe Municipal Airport"));
            _stations.Add(new Station("MLY", "Manley Hot Springs Airport"));
            _stations.Add(new Station("MNL", "Ninoy Aquino International Airport"));
            _stations.Add(new Station("MNT", "Minto Airport"));                          // 5
            _stations.Add(new Station("MOB", "Mobile Municipal Airport"));
            _stations.Add(new Station("MOD", "Modesto Municipal Airport"));
            _stations.Add(new Station("MOT", "Minot International Airport"));
            _stations.Add(new Station("MOU", "Mountain Village Airport"));
        }

        private void CreateDummyFlights()
        {
            this._lastFlightID = 1;
            Flight flight = new Flight(this._lastFlightID);
            flight.AirlineCode = AIRLINE_CODE;
            flight.FlightNumber = 100;
            flight.DepartureStation = _stations[4];
            flight.ArrivalStation = _stations[0];
            this._flights.Add(flight);

            this._lastFlightID = this._lastFlightID + 1;
            flight = new Flight(this._lastFlightID);
            flight.AirlineCode = AIRLINE_CODE;
            flight.FlightNumber = 101;
            flight.DepartureStation = _stations[4];
            flight.ArrivalStation = _stations[1];
            this._flights.Add(flight);

            this._lastFlightID = this._lastFlightID + 1;
            flight = new Flight(this._lastFlightID);
            flight.AirlineCode = AIRLINE_CODE;
            flight.FlightNumber = 102;
            flight.DepartureStation = _stations[4];
            flight.ArrivalStation = _stations[2];
            this._flights.Add(flight);
        }

        private void CreateDummyReservations()
        {
            int currentID = 1;
            Reservation reservation = new Reservation(currentID);
            reservation.FlightID = _flights[0].ID;
            Passenger passenger = new Passenger(0);
            passenger.FirstName = "Tony";
            passenger.LastName = "Stark";
            string birthdateString = "5/29/1970 0:00:00 AM";
            DateTime.TryParse(birthdateString, out passenger.Birthday);
            reservation.Passengers.Add(passenger);
            _reservations.Add(reservation);

            currentID = this._reservations.Count + 1;
            reservation = new Reservation(currentID);
            reservation.FlightID = _flights[1].ID;
            passenger = new Passenger(0);
            passenger.FirstName = "Steve";
            passenger.LastName = "Rogers";
            birthdateString = "7/4/1970 0:00:00 AM";
            DateTime.TryParse(birthdateString, out passenger.Birthday);
            reservation.Passengers.Add(passenger);
            _reservations.Add(reservation);
        }

        public Flight GetFlight(int flightID)
        {
            Flight flight = _flights.Find(m => m.ID == flightID);
            return flight;
        }

        public Flight[] GetFlights()
        {
            return this._flights.ToArray();
        }

        public Station[] GetStations()
        {
            return this._stations.ToArray();
        }

        public int GetNextAvailableFlightID()
        {
            return this._lastFlightID + 1;
        }

        public bool HasDuplicateFlight(Flight flight)
        {
            Flight dupFlight = this._flights.Find(m => m.AirlineCode == flight.AirlineCode
                                                    && m.FlightNumber == flight.FlightNumber);
            if (dupFlight != null)
                return true;

            return false;
        }
    }
}
