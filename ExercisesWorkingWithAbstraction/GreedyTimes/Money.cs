namespace GreedyTimes
{
    public class Money
    {
        public Money(string name, long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public string Name { get; set; }

        public long Amount { get; set; }
    }
}
