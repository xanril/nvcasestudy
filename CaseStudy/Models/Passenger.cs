using CaseStudy.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseStudy.Models
{
    public class Passenger
    {
        [Required]
        [StringLength(64, ErrorMessage = "First Name should have 64 characters maximum only.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Last Name should have 64 characters maximum only.")]
        public string LastName { get; set; }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                CalculateAge();
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
            FirstName = "A";
            LastName = "B";

            // makes sure that initial value of birthdate is always in the past.
            birthdate = DateTime.Now.AddYears(-1).AddDays(-1);

            // and age initial value is 1.
            age = 1;
        }

        public override string ToString()
        {
            return this.LastName + ", " + this.FirstName + "\t" + Birthdate.ToShortDateString();
        }

        private void CalculateAge()
        {
            DateTime today = DateTime.Today;
            age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age))
                age = age - 1;

            if (age < 0)
                age = 0;
        }
    }
}
