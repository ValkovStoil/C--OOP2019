using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedyTimes
{
    public class Bag
    {
        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.GouldAmount = 0;
            this.Gems = new List<Gem>();
            this.Curency = new List<Money>(); ;
        }

        public long Capacity { get; set; }

        public long GouldAmount { get; set; }

        public List<Gem> Gems { get; set; }

        public List<Money> Curency { get; set; }

        public long GetSum()
        {
            var totalSum = this.Gems.Sum(x => x.Amount) + this.Curency.Sum(x => x.Amount);

            return totalSum;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            if(this.GouldAmount != 0)
            {
                result.AppendLine($"<Gold> ${this.GouldAmount}");
                result.AppendLine($"##Gold - {this.GouldAmount}");
            }

            if(this.Gems.Count!= 0)
            {
                var gems = this.Gems
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Amount);

                result.AppendLine($"<Gem> ${this.Gems.Sum(x => x.Amount)}");
                foreach (var gem in gems)
                {
                    result.AppendLine($"##{gem.Name} - {gem.Amount}");
                }
            }

            if(this.Curency.Count != 0)
            {
                var money = this.Curency
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Amount);

                result.AppendLine($"<Gem> ${this.Curency.Sum(x => x.Amount)}");
                foreach (var curency in money)
                {
                    result.AppendLine($"##{curency.Name} - {curency.Amount}");
                }
            }

            return result.ToString();
        }

    }
}
