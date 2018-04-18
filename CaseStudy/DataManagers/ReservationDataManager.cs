using CaseStudy.Models;
using System;
using System.Collections.Generic;

namespace CaseStudy.DataManagers
{
    public class ReservationDataManager
    {
        private static ReservationDataManager instance;
        public static ReservationDataManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReservationDataManager();

                return instance;
            }
        }

        private List<Reservation> reservations;

        private ReservationDataManager()
        {
            reservations = new List<Reservation>();
        }

        public void LoadData()
        {
            CreateDummyReservations();
        }

        private void CreateDummyReservations()
        {
            Reservation reservation = new Reservation();
            reservation.flight = new Flight();
            reservation.flight.AirlineCode = "NV";
            reservation.flight.FlightNumber = 100;
            reservation.flight.ArrivalStation = "MNL";
            reservation.flight.DepartureStation = "MLL";
            Passenger passenger = new Passenger();
            passenger.FirstName = "Tony";
            passenger.LastName = "Stark";
            string birthdateString = "5/29/1970 0:00:00 AM";
            DateTime parsedBirthdate;
            DateTime.TryParse(birthdateString, out parsedBirthdate);
            passenger.Birthdate = parsedBirthdate;
            reservation.AddPassenger(passenger);
            reservations.Add(reservation);

            reservation = new Reservation();
            reservation.flight = new Flight();
            reservation.flight.AirlineCode = "NV";
            reservation.flight.FlightNumber = 101;
            reservation.flight.ArrivalStation = "MNL";
            reservation.flight.DepartureStation = "MLS";
            passenger = new Passenger();
            passenger.FirstName = "Steve";
            passenger.LastName = "Rogers";
            birthdateString = "7/4/1970 0:00:00 AM";
            DateTime.TryParse(birthdateString, out parsedBirthdate);
            passenger.Birthdate = parsedBirthdate;
            reservation.AddPassenger(passenger);
            reservations.Add(reservation);
        }

        public Reservation CreateReservation()
        {
            Reservation reservation = new Reservation();
            reservation.SetPNR(GeneratePNR());
            return reservation;
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return reservations;
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
