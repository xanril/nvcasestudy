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

        private List<Flight> flights;
        private List<Reservation> reservations;
        private List<Station> stations;

        public IEnumerable<Reservation> Reservations
        {
            get { return reservations; }
        }

        private DataManager()
        {
            flights = new List<Flight>();
            reservations = new List<Reservation>();
            stations = new List<Station>();
        }

        public void LoadData()
        {
            CreateDummyFlights();
            CreateDummyReservations();
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

        private void CreateDummyReservations()
        {
            Reservation reservation = new Reservation();
            reservation.flight = new Flight();
            reservation.flight.AirlineCode = flights[0].AirlineCode;
            reservation.flight.FlightNumber = flights[0].FlightNumber;
            reservation.flight.ArrivalStation = flights[0].ArrivalStation;
            reservation.flight.DepartureStation = flights[0].DepartureStation;
            Passenger passenger = new Passenger(0);
            passenger.FirstName = "Tony";
            passenger.LastName = "Stark";
            string birthdateString = "5/29/1970 0:00:00 AM";
            DateTime.TryParse(birthdateString, out passenger.Birthday);
            reservation.Passengers.Add(passenger);
            reservations.Add(reservation);

            reservation = new Reservation();
            reservation.flight = new Flight();
            reservation.flight.AirlineCode = flights[1].AirlineCode;
            reservation.flight.FlightNumber = flights[1].FlightNumber;
            reservation.flight.ArrivalStation = flights[1].ArrivalStation;
            reservation.flight.DepartureStation = flights[1].DepartureStation;
            passenger = new Passenger(0);
            passenger.FirstName = "Steve";
            passenger.LastName = "Rogers";
            birthdateString = "7/4/1970 0:00:00 AM";
            DateTime.TryParse(birthdateString, out passenger.Birthday);
            reservation.Passengers.Add(passenger);
            reservations.Add(reservation);
        }

        public Flight[] GetFlights()
        {
            return this.flights.ToArray();
        }

        public Station[] GetStations()
        {
            return this.stations.ToArray();
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

        public bool AddFlight(Flight flight)
        {
            if(flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            this.flights.Add(flight);
            return true;
        }

        public Flight FindFlight(string airlinecode, int flightNumber)
        {
            Flight flight = null;
            flight = flights.Find(m => m.AirlineCode.Equals(airlinecode) && m.FlightNumber == flightNumber);

            return flight;
        }

        public Reservation CreateReservation()
        {
            Reservation reservation = new Reservation();
            return reservation;
        }

        public Reservation FindReservation(string pnr)
        {
            Reservation reservation = null;
            reservation = reservations.Find(m => m.PNRNumber.Equals(pnr));
            return reservation;
        }
    }
}
