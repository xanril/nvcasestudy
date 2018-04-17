using System;
using System.Text;

namespace CaseStudy.Models
{
    class Passenger
    {
        public int ID
        {
            get; internal set;
        }

        // Max: 64 chars
        public string FirstName;

        // Max: 64 chars
        public string LastName;

        // Should not be a future date
        public DateTime Birthday;

        // Automatically compute
        public int Age
        {
            get; internal set;
        }

        public Passenger(int id)
        {
            this.ID = id;
        }

        public string GetInfo()
        {
            return this.LastName + ", " + this.FirstName + "\t" + Birthday.ToShortDateString();
        }
    }
}
