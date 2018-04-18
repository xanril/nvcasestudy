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
        

        public SetFlightPassengersScreen(Reservation reservation)
        {
            this.reservation = reservation;
            passenger = new Passenger();
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

                case SetPassengerStates.StateLastName:
                    Console.Write("Last Name: ");
                    break;

                case SetPassengerStates.StateBirthday:
                    Console.Write("Birthday (MM/DD/YYYY): ");
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

                            if(reservation.Passengers.Count<Passenger>() == reservation.PassengerCount)
                            {
                                ScreenManager.GetInstance().PushScreen(new ConfirmBookingScreen(reservation));
                            }
                            else
                            {
                                passenger = new Passenger();
                                currState = SetPassengerStates.StateFirstName;
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
