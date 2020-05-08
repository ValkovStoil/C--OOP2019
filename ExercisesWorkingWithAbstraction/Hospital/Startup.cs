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
            var departaments = new List<Departament>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                var hospitalInfo = command.Split();
                var departament = hospitalInfo[0];
                var firstName = hospitalInfo[1];
                var lastName = hospitalInfo[2];
                var pacient = hospitalInfo[3];
                var fullName = firstName + lastName;

                var doctor = new Doctor(firstName, lastName);
                var pactient = new Pacient(pacient,departament);

                if (!doctors.Any(x=>x.FullName == fullName))
                {
                    doctors.Add(doctor);
                }

                if (!departaments.Any(x=>x.Name == departament))
                {
                    departaments.Add(new Departament(departament));
                }
                
                bool hasSpace = departaments.First(x => x.Name == departament)
                    .Capacity > 0;

                //departaments.First(x => x.Name == departament).Capacity = 0;

                //TODO

                //    if (hasSpace)
                //    {
                //        var room = 0;
                //        doctors[fullName].Add(pacient);

                //        for (int st = 0; st < departments[departament].Count; st++)
                //        {
                //            if (departments[departament][st].Count < 3)
                //            {
                //                room = st;
                //                break;
                //            }
                //        }
                //        departments[departament][room].Add(pacient);
                //    }

                //    command = Console.ReadLine();
                //}

                //command = Console.ReadLine();

                //while (command != "End")
                //{
                //    var categories = command.Split();

                //    if (categories.Length == 1)
                //    {
                //        Console.WriteLine(string.Join("\n", departments[categories[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                //    }
                //    else if (categories.Length == 2 && int.TryParse(categories[1], out int staq))
                //    {
                //        Console.WriteLine(string.Join("\n", departments[categories[0]][staq - 1].OrderBy(x => x)));
                //    }
                //    else
                //    {
                //        Console.WriteLine(string.Join("\n", doctors[categories[0] + categories[1]].OrderBy(x => x)));
                //    }
                command = Console.ReadLine();
            }
        }
    }
}
