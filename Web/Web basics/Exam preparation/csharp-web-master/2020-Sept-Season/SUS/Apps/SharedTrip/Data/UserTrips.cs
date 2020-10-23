namespace SharedTrip.Data
{
    using System;
    public class UserCard
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
