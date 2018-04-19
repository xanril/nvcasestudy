using CaseStudy.Helpers;
using CaseStudy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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

        private const string FILENAME = "ReservationData.json";
        private List<Reservation> reservations;

        private ReservationDataManager()
        {
            reservations = new List<Reservation>();
        }

        public void LoadData()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);
            FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists == false)
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
                List<Reservation> resultReservations = JsonConvert.DeserializeObject<List<Reservation>>(fileContents);

                if (resultReservations != null)
                    this.reservations = resultReservations;
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
                    serializer.Serialize(writer, this.reservations);
                }
            }
        }

        private void CreateDummyReservations()
        {
            Reservation reservation = CreateReservation();
            reservation.TargetFlight = new Flight();
            reservation.TargetFlight.AirlineCode = "NV";
            reservation.TargetFlight.FlightNumber = 100;
            reservation.TargetFlight.ArrivalStation = "MNL";
            reservation.TargetFlight.DepartureStation = "MLL";
            Passenger passenger = new Passenger();
            passenger.FirstName = "Tony";
            passenger.LastName = "Stark";
            string birthdateString = "5/29/1970 0:00:00 AM";
            DateTime parsedBirthdate;
            DateTime.TryParse(birthdateString, out parsedBirthdate);
            passenger.Birthdate = parsedBirthdate;
            reservation.AddPassenger(passenger);
            reservations.Add(reservation);

            reservation = CreateReservation();
            reservation.TargetFlight = new Flight();
            reservation.TargetFlight.AirlineCode = "NV";
            reservation.TargetFlight.FlightNumber = 101;
            reservation.TargetFlight.ArrivalStation = "MNL";
            reservation.TargetFlight.DepartureStation = "MLS";
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
            string generatedPNR = PNRGenerator.Get(new Random((int)(DateTime.Now.Ticks % int.MaxValue)));
            Reservation reservation = new Reservation(generatedPNR);
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

            SaveData();
        }
    }
}
