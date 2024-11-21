namespace FoglalasLib
{
    public class Room(string id, int capacity)
    {
        public TimeTable TimeTable { get; set; } = new();
        public string Id { get; set; } = id;
        public int Capacity { get; set; } = capacity;

        public virtual void Reserve(Reservation reservation) { }
    }
}
