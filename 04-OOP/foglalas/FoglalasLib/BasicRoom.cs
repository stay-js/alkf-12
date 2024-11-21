namespace FoglalasLib
{
    public sealed class BasicRoom(string id, int capacity) : Room(id, capacity)
    {
        public override void Reserve(Reservation reservation) => TimeTable += reservation;

        public override string ToString() => $"{Id}:\nFoglalt időpontok:\n{TimeTable}";
    }
}
