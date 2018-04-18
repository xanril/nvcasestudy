﻿using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy.Booking.Screens
{
    class SearchPNRScreen : IScreen
    {
        private const string KEY_BACK_TO_MENU = "X";

        public void Display()
        {
            Console.WriteLine("RESERVATIONS > SEARCH BY PNR");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Enter PNR or press 'X' to go back to menu: ");
        }

        public void ProcessInput(string userInput)
        {
            userInput = userInput.Trim();
            userInput = userInput.ToUpper();

            if(userInput == KEY_BACK_TO_MENU)
            {
                Console.WriteLine("Back To Menu selected.\n");
                ScreenManager.GetInstance().PopScreenUntilTargetType(typeof(ReservationsScreen));
                return;
            }

            Reservation reservation = DataManager.GetInstance().FindReservation(userInput);
            
            if(reservation == null)
            {
                Console.WriteLine("No Reservation record exists for PNR " + userInput);
            }
            else
            {
                Console.WriteLine("Reservation record found.");
                Console.WriteLine(reservation.GetInfo());
            }
        }
    }
}