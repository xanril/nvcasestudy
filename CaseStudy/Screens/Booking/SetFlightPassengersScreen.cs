using CaseStudy.Helpers;
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
            ValidationHelperResult validationResult = null;

            switch (currState)
            {
                case SetPassengerStates.StateMaxCount:

                    int passengerCount = 0;
                    if(int.TryParse(userInput, out passengerCount))
                    {
                        if(passengerCount > 5)
                            Console.WriteLine("Passenger count should not be more than 5");
                        else
                        {
                            this.targetPassengerCount = passengerCount;
                            currState = SetPassengerStates.StateFirstName;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Passenger count should be numeric");
                    }
                    break;

                case SetPassengerStates.StateFirstName:

                    validationResult = ValidationHelper.ValidateProperty<Passenger>(passenger, nameof(passenger.FirstName), userInput);
                    if (validationResult.HasError)
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    { 
                        passenger.FirstName = userInput;
                        currState = SetPassengerStates.StateLastName;
                    }
                    break;

                case SetPassengerStates.StateLastName:

                    validationResult = ValidationHelper.ValidateProperty<Passenger>(passenger, nameof(passenger.LastName), userInput);
                    if (validationResult.HasError)
                        Console.Write(validationResult.GetErrorMessages());
                    else
                    { 
                        passenger.LastName = userInput;
                        currState = SetPassengerStates.StateBirthday;
                    }
                    
                    break;

                case SetPassengerStates.StateBirthday:

                    userInput = userInput.Trim();
                    DateTime birthdate = DateTime.Now;

                    if (DateTime.TryParse(userInput, out birthdate))
                    {
                        // TODO check birthdate
                        if (ValidationHelper.IsPastDate(birthdate) == false)
                            Console.WriteLine("Birthdate should be a past date.");
                        else
                        {
                            passenger.Birthdate = birthdate;
                            reservation.AddPassenger(passenger);
                            Console.WriteLine("[Passenger {0}] Added - " + passenger.ToString(), currentPassenger);

                            if (reservation.Passengers.Count<Passenger>() == targetPassengerCount)
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
