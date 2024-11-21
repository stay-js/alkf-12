namespace FoglalasLib
{
    public interface IReservation
    {
        public string RoomId { get; init; }
        public DateTime Start { get; init; }
        public DateTime End { get; init; }
    }
}
