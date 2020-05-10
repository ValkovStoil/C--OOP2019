namespace GreedyTimes
{
    public class Gem
    {
        public Gem(string name, long amount)
        {
           this.Name = name;
           this.Amount = amount;
        }

        public string Name { get; set; }

        public long Amount { get; set; }
    }
}
