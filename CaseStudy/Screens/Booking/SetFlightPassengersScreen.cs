using CaseStudy.Models;
using CaseStudy.Screens;
using System;
using System.Linq;

namespace CaseStudy.Booking.Screens
{
    class SetFlightPassengersScreen : IScreen
    {
        private enum SetPassengerStates
        {
            StateMaxCount = 0,
            StateFirstName,
            StateLastName,
            StateBirthday,
            StateEnd
        }

        private Reservation reservation;
        private Passenger passenger;
        private SetPassengerStates currState = SetPassengerStates.StateMaxCount;
        private int targetPassengerCount;
        private int currentPassenger;

        public SetFlightPassengersScreen(Reservation reservation)
        {
            this.reservation = reservation;
            passenger = new Passenger();
            targetPassengerCount = 1;
            currentPassenger = 1;
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
                    Console.Write("\n[Passenger {0}] First Name: ", currentPassenger);
                    break;

                case SetPassengerStates.StateLastName:
                    Console.Write("[Passenger {0}] Last Name: ", currentPassenger);
                    break;

                case SetPassengerStates.StateBirthday:
                    Console.Write("[Passenger {0}] Birthday (MM/DD/YYYY): ", currentPassenger);
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
                        this.targetPassengerCount = passengerCount;
                        currState = SetPassengerStates.StateFirstName;
                    }
                    else
                    {
                        Console.WriteLine("Passenger count should be numeric");
                    }
                   break;

                case SetPassengerStates.StateFirstName:

                    try
                    {
                        passenger.FirstName = userInput;
                        currState = SetPassengerStates.StateLastName;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case SetPassengerStates.StateLastName:
                    try
                    {
                        passenger.LastName = userInput;
                        currState = SetPassengerStates.StateBirthday;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case SetPassengerStates.StateBirthday:

                    userInput = userInput.Trim();
                    DateTime birthdate = DateTime.Now;

                    if (DateTime.TryParse(userInput, out birthdate))
                    {
                        try
                        {
                            passenger.Birthdate = birthdate;
                            reservation.AddPassenger(passenger);
                            Console.WriteLine("[Passenger {0}] Added - " + passenger.ToString(), currentPassenger);

                            if(reservation.Passengers.Count<Passenger>() == targetPassengerCount)
                            {
                                ScreenManager.GetInstance().PushScreen(new ConfirmBookingScreen(reservation));
                            }
                            else
                            {
                                passenger = new Passenger();
                                currState = SetPassengerStates.StateFirstName;
                                currentPassenger = currentPassenger + 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot recognize Date Format. Please try again.");
                    }
                    break;
            }
        }
    }
}
