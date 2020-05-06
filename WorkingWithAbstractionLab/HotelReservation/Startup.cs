namespace HotelReservation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {

            var inputInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var pricePerDay = decimal.Parse(inputInfo[0]);
            var numberOfDays = int.Parse(inputInfo[1]);
            var season = inputInfo[2].ToLower();
            var discountType = "none";

            if(inputInfo.Length > 3)
            {
                discountType = inputInfo[3].ToLower();
            }

            var calculator = new PriceCalculator(pricePerDay, numberOfDays);

            var calculatePrice = calculator.Calculate(Enum.Parse<Seasons>(season), Enum.Parse<Discount>(discountType));

            Console.WriteLine($"{calculatePrice:F2}");

        }
    }
}
