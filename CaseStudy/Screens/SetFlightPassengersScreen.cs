using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    class SetFlightPassengersScreen : IScreen
    {
        private enum SetPassengerStates
        {
            StateMaxCount = 0,
            StateFirstName,
            StateLastName,
            StateBirthday
        }

        private Reservation reservation;
        private SetPassengerStates currState = SetPassengerStates.StateMaxCount;
        

        public SetFlightPassengersScreen(Reservation reservation)
        {
            this.reservation = reservation;
        }

        public void Display()
        {
            Console.WriteLine("RESERVATIONS > SET PASSENGERS");
        }

        public void ShowInputPrompt()
        {
            switch(currState)
            {
                case SetPassengerStates.StateMaxCount:
                    Console.Write("Passenger count (max 5): ");
                    break;

                case SetPassengerStates.StateFirstName:
                    Console.Write("First Name: ");
                    break;
            }
        }

        public void ProcessInput(string userInput)
        {
            switch(currState)
            {
                case SetPassengerStates.StateMaxCount:

                    int passengerCount = 0;
                    if(int.TryParse(userInput, out passengerCount))
                    {
                        try
                        {
                            reservation.PassengerCount = passengerCount;
                            currState = SetPassengerStates.StateFirstName;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                   break;

                case SetPassengerStates.StateFirstName:
                    
                    break;
            }
        }
    }
}
