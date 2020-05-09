namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Doctor
    {
        private string firstName;
        private string lastName;

        public Doctor(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.FullName = $"{this.firstName}{this.lastName}";
            this.Patients = new List<Patient>();
        }

        public string FullName { get; private set; }

        public List<Patient> Patients { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            var patients = this.Patients.OrderBy(x => x.Name).ToList();

            foreach (var patient in patients)
            {
                result.AppendLine(patient.Name);
            }

            return result.ToString();
        }

        public void AddPatient(Patient patientName)
        {
            this.Patients.Add(patientName);
        }
    }
}
