namespace FoglalasLib
{
    public class Reservation : IReservation
    {
        public string RoomId { get; init; }
        public DateTime Start { get; init; }
        public DateTime End { get; init; }
        public string TeacherId { get; init; }

        public Reservation(DateTime start, int duration, string roomId, string teacher)
        {
            if (duration < 0 || duration % 15 != 0) throw new DurationException();

            RoomId = roomId;
            TeacherId = teacher;
            Start = start;
            End = Start.AddMinutes(duration);

        }

        private Reservation(string[] parts) : this(DateTime.Parse(parts[0]), int.Parse(parts[1]), parts[2], parts[3]) { }
        public Reservation(string line) : this(line.Split(';')) { }

        public override string ToString() => $"{Start} - {End:t} {TeacherId}";
    }
}
