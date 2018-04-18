using CaseStudy.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseStudy.Models
{
    class Passenger
    {
        private string firstName;

        [Required]
        [StringLength(64, ErrorMessage = "First Name should have 64 characters maximum only.")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Passenger>(this, nameof(FirstName), value);
                if (validationResult.IsValid)
                    throw new Exception(validationResult.GetErrorMessages());

                firstName = value;
            }
        }

        private string lastName;

        [Required]
        [StringLength(64, ErrorMessage = "Last Name should have 64 characters maximum only.")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                ValidationHelperResult validationResult = ValidationHelper.ValidateProperty<Passenger>(this, nameof(LastName), value);
                if (validationResult.IsValid)
                    throw new Exception(validationResult.GetErrorMessages());

                lastName = value;
            }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                birthday = value;
                //TODO: calculate age here
            }
        }

        // Automatically compute
        private int age;
        public int Age
        {
            get { return age; }
        }

        public Passenger()
        {
            firstName = "A";
            LastName = "B";
            age = 1;
        }

        public string GetInfo()
        {
            return this.LastName + ", " + this.FirstName + "\t" + Birthday.ToShortDateString();
        }
    }
}
