namespace FoglalasLib
{
    public interface IReservation
    {
        public string RoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
