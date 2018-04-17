﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class ReservationsScreen : IScreen
    {
        private const string MENU_BOOK_FLIGHT = "1";
        private const string MENU_LIST_RESERVATIONS = "2";
        private const string MENU_SEARCH_PNR = "3";
        private const string MENU_BACK = "4";

        public void Display()
        {
            Console.WriteLine("RESERVATIONS");
            Console.WriteLine("[" + MENU_BOOK_FLIGHT + "] Book a Flight");
            Console.WriteLine("[" + MENU_LIST_RESERVATIONS + "] List All Reservations");
            Console.WriteLine("[" + MENU_SEARCH_PNR + "] Search By PNR");
            Console.WriteLine("[" + MENU_BACK + "] Back to Main Menu");
        }

        public void ShowInputPrompt()
        {
            Console.WriteLine("");
            Console.Write("Select Item: ");
        }

        public void ProcessInput(string userInput)
        {
            switch (userInput)
            {
                case MENU_BOOK_FLIGHT:
                    Console.WriteLine("Book a Flight selected.\n");
                    //Flight newFlight = DataManager.GetInstance().CreateFlight();
                    //ScreenManager.GetInstance().PushScreen(new SetAirlineCodeScreen(newFlight));
                    break;

                case MENU_LIST_RESERVATIONS:
                    Console.WriteLine("List All Reservations selected.\n");
                    ScreenManager.GetInstance().PushScreen(new ListReservationsScreen());
                    break;

                case MENU_SEARCH_PNR:
                    Console.WriteLine("List All Reservations selected.\n");
                    ScreenManager.GetInstance().PushScreen(new SearchPNRScreen());
                    break;

                case MENU_BACK:
                    Console.WriteLine("Back To Menu selected.\n");
                    ScreenManager.GetInstance().PopScreen();
                    break;

                default:
                    Console.WriteLine("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}