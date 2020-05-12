using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;

namespace GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var itemsQuantity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var bag = new Bag(bagCapacity);

            //long gold = 0;
            //long gems = 0;
            //long money = 0;
            //TODO
            for (int i = 0; i < itemsQuantity.Length; i += 2)
            {
                var name = itemsQuantity[i];
                var itemPrice = long.Parse(itemsQuantity[i + 1]);

                string type = string.Empty;

                if (name.Length == 3)
                {
                    type = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    type = "Gold";
                }

                var totalSumInBag = bag.GetSum();
                
                if (type == string.Empty)
                {
                    continue;
                }
                else if (bag.Capacity < totalSumInBag + itemPrice)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":
                        var gem = new Gem(name, itemPrice);

                        if (!bag.Gems.Any(x=>x.Name == gem.Name))
                        {
                            if (bag.GouldAmount != 0)
                            {
                                if (itemPrice > bag.GouldAmount)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.Gems.Sum(x=>x.Amount) + itemPrice > bag.GouldAmount)
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        var money = new Money(name, itemPrice);

                        if (!bag.Curency.Any(x=>x.Name == money.Name))
                        {
                            if (bag.Gems.Count != 0)
                            {
                                if (itemPrice > bag.Gems.Sum(x => x.Amount))
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.GouldAmount + itemPrice > bag.Gems.Sum(x=>x.Amount))
                        {
                            continue;
                        }
                        break;
                }
                //TODO see the first test

                //if (!bag.ContainsKey(type))
                //{
                //    bag[type] = new Dictionary<string, long>();
                //}

                //if (!bag[type].ContainsKey(name))
                //{
                //    bag[type][name] = 0;
                //}

                //bag[type][name] += itemPrice;
                if (type == "Gold")
                {
                    bag.GouldAmount += itemPrice;
                }
                else if (type == "Gem")
                {
                    var gem = new Gem(name, itemPrice);

                    if (bag.Gems.Any(x => x.Name == name))
                    {
                        bag.Gems.First(x => x.Name == name).Amount += itemPrice;
                    }
                    else
                    {
                        bag.Gems.Add(gem);
                    }
                }
                else if (type == "Cash")
                {
                    var money = new Money(name, itemPrice);
                    if (bag.Curency.Any(x => x.Name == name))
                    {
                        bag.Curency.First(x => x.Name == name).Amount += itemPrice;
                    }
                    else
                    {
                        bag.Curency.Add(money);
                    }
                }
            }

            Console.WriteLine(bag);
        }
    }
}