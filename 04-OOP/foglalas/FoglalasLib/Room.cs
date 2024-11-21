namespace FoglalasLib
{
    public class Room(string id, int capacity)
    {
        public TimeTable TimeTable { get; protected set; } = new();
        public string Id { get; init; } = id;
        public int Capacity { get; init; } = capacity;

        public virtual void Reserve(Reservation reservation) { }
    }
}
