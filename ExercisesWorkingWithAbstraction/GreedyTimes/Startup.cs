namespace GreedyTimes
{
    using System;
    using System.Linq;



    public class Potato
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var itemsQuantity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var bag = new Bag(bagCapacity);

            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < itemsQuantity.Length; i += 2)
            {
                var key = itemsQuantity[i];
                var value = long.Parse(itemsQuantity[i + 1]);

                InsertItem(key, value, bag);
            }

            Console.WriteLine(bag.ToString());

        }

        private static void InsertItem(string key, long value, Bag bag)
        {
            if (key.Length == 3)
            {
                Cash cash = new Cash(key, value);
                bag.AddCashItem(cash);
            }
            else if (key.ToLower().Equals("gold"))
            {
                Gold gold = new Gold(key, value);
                bag.AddGoldItem(gold);
            }
            else if (key.Length >= 4 && key.ToLower().EndsWith("gem"))
            {
                Gem gem = new Gem(key, value);
                bag.AddGemItem(gem);
            }
        }
    }
}