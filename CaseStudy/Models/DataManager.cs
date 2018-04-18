﻿using System;
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

        private List<Reservation> reservations;
        private List<Station> stations;

        public IEnumerable<Reservation> Reservations
        {
            get { return reservations; }
        }

        private DataManager()
        {
            reservations = new List<Reservation>();
            stations = new List<Station>();
        }

        public void LoadData()
        {
            CreateDummyReservations();
        }

        private void CreateDummyReservations()
        {
            //Reservation reservation = new Reservation();
            //reservation.flight = new Flight();
            //reservation.flight.AirlineCode = flights[0].AirlineCode;
            //reservation.flight.FlightNumber = flights[0].FlightNumber;
            //reservation.flight.ArrivalStation = flights[0].ArrivalStation;
            //reservation.flight.DepartureStation = flights[0].DepartureStation;
            //Passenger passenger = new Passenger();
            //passenger.FirstName = "Tony";
            //passenger.LastName = "Stark";
            //string birthdateString = "5/29/1970 0:00:00 AM";
            //DateTime parsedBirthdate;
            //DateTime.TryParse(birthdateString, out parsedBirthdate);
            //passenger.Birthdate = parsedBirthdate;
            //reservation.AddPassenger(passenger);
            //reservations.Add(reservation);

            //reservation = new Reservation();
            //reservation.flight = new Flight();
            //reservation.flight.AirlineCode = flights[1].AirlineCode;
            //reservation.flight.FlightNumber = flights[1].FlightNumber;
            //reservation.flight.ArrivalStation = flights[1].ArrivalStation;
            //reservation.flight.DepartureStation = flights[1].DepartureStation;
            //passenger = new Passenger();
            //passenger.FirstName = "Steve";
            //passenger.LastName = "Rogers";
            //birthdateString = "7/4/1970 0:00:00 AM";
            //DateTime.TryParse(birthdateString, out parsedBirthdate);
            //passenger.Birthdate = parsedBirthdate;
            //reservation.AddPassenger(passenger);
            //reservations.Add(reservation);
        }

        public Station[] GetStations()
        {
            return this.stations.ToArray();
        }

        public Reservation CreateReservation()
        {
            Reservation reservation = new Reservation();
            reservation.SetPNR(GeneratePNR());
            return reservation;
        }

        public Reservation FindReservation(string pnr)
        {
            Reservation reservation = null;
            reservation = reservations.Find(m => m.PNR.Equals(pnr));
            return reservation;
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentException(nameof(reservation));

            this.reservations.Add(reservation);
            //TODO: Save Reservations to text file.
        }

        private string GeneratePNR()
        {
            return "GeneratedPNR";
        }
    }
}
