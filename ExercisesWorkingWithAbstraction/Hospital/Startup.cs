namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            var doctors = new List<Doctor>();
            var departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                var commandInfo = command.Split();
                var departament = commandInfo[0];
                var firstName = commandInfo[1];
                var lastName = commandInfo[2];
                var patientName = commandInfo[3];
                var fullName = firstName + lastName;

                if (!doctors.Any(x=>x.FullName == fullName))
                {
                    var doctor = new Doctor(firstName, lastName);
                    doctors.Add(doctor);
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                var hasSpace = departments[departament].SelectMany(x => x).Count() < 60;
                if (hasSpace)
                {
                    var room = 0;
                    var patient = new Patient(patientName);
                    doctors.FirstOrDefault(x => x.FullName == fullName).AddPatient(patient);
                    //TODO
                    for (int st = 0; st < departments[departament].Count; st++)
                    {
                        if (departments[departament][st].Count < 3)
                        {
                            room = st;
                            break;
                        }
                    }
                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var requestInfo = command.Split();

                if (requestInfo.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[requestInfo[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (requestInfo.Length == 2 && int.TryParse(requestInfo[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[requestInfo[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    var name = $"{requestInfo[0]}{requestInfo[1]}";
                    var doctorPatients = doctors.FirstOrDefault(x => x.FullName == name);

                    Console.Write(doctorPatients);
                }
                command = Console.ReadLine();
            }
        }
    }
}
