namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private List<Item> bag;
        private long capacity;
        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.bag = new List<Item>();
        }

        public long GoldItemsValue
        {
            get
            {
                return bag.Where(i => i is Gold).Sum(i => i.Value);
            }
        }

        public long CashItemsValue
        {
            get
            {
                return bag.Where(i => i is Cash).Sum(i => i.Value);
            }
        }

        public long GemItemsValue
        {
            get
            {
                return bag.Where(i => i is Gem).Sum(i => i.Value);
            }
        }

        public void AddGoldItem(Gold item)
        {
            if(capacity >= current + item.Value)
            {
                var goldItem = GetGoldItem();
                if(goldItem.Any(gi=>gi.Key == item.Key))
                {
                    goldItem.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public void AddCashItem(Cash item)
        {
            if (capacity >= current + item.Value && GemItemsValue >= CashItemsValue + item.Value)
            {
                var cashItem = GetCashItem();
                if (cashItem.Any(gi => gi.Key == item.Key))
                {
                    cashItem.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public void AddGemItem(Gem item)
        {
            if (capacity >= current + item.Value && GoldItemsValue >= GemItemsValue + item.Value)
            {
                var gemItem = GetGemItem();
                if (gemItem.Any(gi => gi.Key == item.Key))
                {
                    gemItem.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        private List<Item> GetGemItem()
        {
            return bag.Where(i => i is Gem).ToList();
        }

        private List<Item> GetCashItem()
        {
            return bag.Where(i => i is Cash).ToList();
        }

        private List<Item> GetGoldItem()
        {
            return bag.Where(i => i is Gold).ToList();
        }

        public override string ToString()
        {
            var outputInfo = new StringBuilder();

            var dictionary = bag.GroupBy(i => i.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kvp in dictionary.OrderByDescending(kv => kv.Value.Sum(i => i.Value)))
            {
                if (kvp.Key == "Cash")
                {
                    outputInfo.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "Gold")
                {
                    outputInfo.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "Gem")
                {
                    outputInfo.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Value)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(i=> i.Key).ThenBy(i=> i.Value))
                {
                    outputInfo.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return outputInfo.ToString().TrimEnd();
        }
    }
}
