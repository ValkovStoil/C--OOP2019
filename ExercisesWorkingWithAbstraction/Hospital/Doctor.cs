namespace Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        private string firstName;
        private string lastName;

        public Doctor(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.FullName = $"{this.firstName}{this.lastName}";
            this.Pacients = new List<Pacient>();
        }

        public string FullName { get; private set; }

        public List<Pacient> Pacients { get; set; }
    }
}
