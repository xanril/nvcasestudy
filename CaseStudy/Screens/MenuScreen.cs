using System;

namespace CaseStudy.Screens
{
    class MenuScreen : IScreen
    {
        private const string MENU_FLIGHT_MAINTENANCE = "1";
        private const string MENU_RESERVATION = "2";
        private const string MENU_EXIT = "3";

        public void Display()
        {
            Console.WriteLine("MAIN MENU:");
            Console.WriteLine("[" + MENU_FLIGHT_MAINTENANCE + "] Go to Flight Maintenance Screen");
            Console.WriteLine("[" + MENU_RESERVATION + "] Go to Reservation Screen");
            Console.WriteLine("[" + MENU_EXIT + "] Exit");
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
                case MENU_FLIGHT_MAINTENANCE:
                    Console.WriteLine("Flight Maintenance Selected.\n");
                    ScreenManager.GetInstance().PushScreen(new FlightMaintenanceScreen());
                    break;

                case MENU_RESERVATION:
                    Console.WriteLine("Reservations Selected.\n");
                    ScreenManager.GetInstance().PushScreen(new ReservationsScreen());
                    break;

                case MENU_EXIT:
                    Console.WriteLine("Exit Selected.");
                    ScreenManager.GetInstance().PopScreen();
                    break;

                default:
                    Console.WriteLine("Cannot recognize menu item. Please try again.");
                    break;
            }
        }
    }
}
