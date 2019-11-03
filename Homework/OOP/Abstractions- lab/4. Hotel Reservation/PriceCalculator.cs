namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal PricePerDay, int NumOfDays, int Season, int Disscount)
        {
            decimal priceWithoutDisscount = (PricePerDay * Season) * NumOfDays;
            decimal totalPrice = priceWithoutDisscount - (Disscount / 100m * priceWithoutDisscount);

            return totalPrice;
        }
    }
}
