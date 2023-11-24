namespace ReservationsApp.Data.Reservations
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public DateTime ReservationStart { get; set; }

        public int ReservationLength { get; set; }
    }
}
