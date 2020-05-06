namespace CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarSalesman
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();
            var engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];
                var power = int.Parse(parameters[1]);

                var displacement = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {
                    engines.Add(new Engine(model, power, displacement));
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    engines.Add(new Engine(model, power, efficiency));
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            var carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];
                var engineModel = parameters[1];
                var engine = engines.FirstOrDefault(x => x.model == engineModel);

                var weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else if (parameters.Length == 3)
                {
                    var color = parameters[2];
                    cars.Add(new Car(model, engine, color));
                }
                else if (parameters.Length == 4)
                {
                    var color = parameters[3];
                    cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

}
