namespace FoglalasLib
{
    public class TimeTable
    {
        private readonly List<Reservation> _reservations;

        private TimeTable(List<Reservation> reservations) => _reservations = reservations;

        public TimeTable() : this([]) { }

        public bool IsOccupied(DateTime start, int duration) => _reservations
            .Exists(x => x.Start < start.AddMinutes(duration) && start < x.End);

        public bool IsOccupied(DateTime start, DateTime end) => _reservations
            .Exists(x => x.Start < end && start < x.End);

        public IEnumerable<Reservation> GetReservationsByTeacherId(string teacherId) => _reservations
            .Where(x => string.Equals(x.TeacherId, teacherId, StringComparison.CurrentCultureIgnoreCase));

        public static TimeTable operator +(TimeTable timeTable, Reservation reservation)
        {
            if (timeTable.IsOccupied(reservation.Start, reservation.End)) throw new ReservationException();

            var newReservations = timeTable._reservations;
            newReservations.Add(reservation);

            return new TimeTable(newReservations);
        }

        public override string ToString() => string.Join("\n", _reservations.OrderBy(x => x.Start));
    }
}
