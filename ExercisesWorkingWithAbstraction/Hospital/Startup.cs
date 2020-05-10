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
            var departments = new Dictionary<string, Departament>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                var commandInfo = command.Split();
                var departament = commandInfo[0];
                var firstName = commandInfo[1];
                var lastName = commandInfo[2];
                var patientName = commandInfo[3];
                var fullName = firstName + lastName;

                if (!doctors.Any(x => x.FullName == fullName))
                {
                    var doctor = new Doctor(firstName, lastName);
                    doctors.Add(doctor);
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new Departament();
                }
                ;
                var hasSpace = departments[departament].Rooms.Any(x => x.PatientsInRoom.Count < 3);

                if (hasSpace)
                {
                    var patient = new Patient(patientName);
                    doctors.FirstOrDefault(x => x.FullName == fullName).AddPatient(patient);

                    var freeBedInRoom = departments[departament].Rooms.FirstOrDefault(x => x.PatientsInRoom.Count < 3);
                    freeBedInRoom.PatientsInRoom.Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var requestInfo = command.Split();
                var roomNumber = 0;

                if (requestInfo.Length == 1)
                {
                    var department = departments[requestInfo[0]];
                    var rooms = department.Rooms;

                    foreach (var room in rooms)
                    {
                        if (room.PatientsInRoom.Count != 0)
                        {
                            Console.WriteLine(string.Join(Environment.NewLine, room.PatientsInRoom));
                        }
                    }

                }
                else if (requestInfo.Length == 2 && int.TryParse(requestInfo[1], out roomNumber))
                {
                    var department = departments[requestInfo[0]];
                    var room = department.Rooms[roomNumber - 1];

                    Console.WriteLine(string.Join("\n", room.PatientsInRoom.OrderBy(x => x.Name)));
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
