namespace CaseStudy.Models
{
    class Station
    {
        public string Code
        {
            get; internal set;
        }

        public string Name
        {
            get; internal set;
        }

        public Station(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
