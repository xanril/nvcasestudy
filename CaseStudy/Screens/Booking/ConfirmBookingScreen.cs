﻿using CaseStudy.DataManagers;
using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Screens.Booking
{
    class ConfirmBookingScreen : IScreen
    {
        private const string KEY_CONFIRM_BOOKING = "Y";
        private const string KEY_CANCEL_BOOKING = "N";

        private Reservation reservation;

        public ConfirmBookingScreen(Reservation reservation)
        {
            this.reservation = reservation;
        }

        public void Display()
        {
            Console.WriteLine("\nRESERVATIONS > BOOKING SUMMARY");
            Console.WriteLine("---------------------------------------------------");
            Console.Write(reservation.ToString());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
        }

        public void ShowInputPrompt()
        {
            Console.Write("Confirm this booking? (Y/N): ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.ToUpper();

            switch(userInput)
            {
                case KEY_CONFIRM_BOOKING:

                    try
                    {
                        ReservationDataManager.Instance.AddReservation(reservation);
                        Console.WriteLine("Booking saved.");
                        ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case KEY_CANCEL_BOOKING:

                    Console.WriteLine("Booking cancelled.");
                    ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                    break;

                default:

                    Console.WriteLine("Cannot recognize input. Please try again.");
                    break;
            }
        }
    }
}
