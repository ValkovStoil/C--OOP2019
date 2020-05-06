namespace HotelReservation
{
    public class PriceCalculator
    {
        public PriceCalculator(decimal pricePerDay, int days)
        {
            this.PricePerDay = pricePerDay;
            this.Days = days;
        }

        public decimal PricePerDay { get; set; }

        public int Days { get; set; }


        public decimal Calculate(Seasons seasonPrice ,Discount discount)
        {
            var discountPrice = this.PricePerDay * (int)seasonPrice * this.Days * (int)discount / 100;

            var calculatePrice = this.PricePerDay * (int)seasonPrice * this.Days - discountPrice;

            return calculatePrice;
        }
    }
}
