namespace FoglalasLib
{
    public class Reservation : IReservation
    {
        public string RoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string TeacherId { get; set; }

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
