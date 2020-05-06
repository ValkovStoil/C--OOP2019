namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];

                var engineSpeed = int.Parse(parameters[1]);
                var enginePower = int.Parse(parameters[2]);
                var engine = new Engine(engineSpeed, enginePower);

                var cargoWeight = int.Parse(parameters[3]);
                var cargoType = parameters[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                var tiresInput = parameters
                    .Skip(5)
                    .ToArray();

                var tires = new List<Tire>();

                for (int tireInfo = 0; tireInfo < tiresInput.Length; tireInfo+=2)
                { 
                    var pressure = double.Parse(tiresInput[tireInfo]);
                    var age = int.Parse(tiresInput[tireInfo + 1]);

                    var tire =new Tire(pressure, age);

                    tires.Add(tire);
                }

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                var fragile =cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(p => p.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                var flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
