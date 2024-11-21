namespace FoglalasLib
{
    public class TimeTable
    {
        public List<Reservation> Reservations { get; }

        private TimeTable(List<Reservation> reservations) => Reservations = reservations;

        public TimeTable() : this([]) { }

        public bool IsOccupied(DateTime start, int duration) => Reservations
            .Exists(x => x.Start < start.AddMinutes(duration) && start < x.End);

        public bool IsOccupied(DateTime start, DateTime end) => Reservations
            .Exists(x => x.Start < end && start < x.End);

        public static TimeTable operator +(TimeTable timeTable, Reservation reservation)
        {
            if (timeTable.IsOccupied(reservation.Start, reservation.End)) throw new ReservationException();

            var newReservations = timeTable.Reservations;
            newReservations.Add(reservation);

            return new TimeTable(newReservations);
        }

        public override string ToString() => string.Join("\n", Reservations.OrderBy(x => x.Start));
    }
}
