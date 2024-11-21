namespace FoglalasLib
{
    public sealed class SpecialRoom(string id, int capacity, int cleaningTime) : Room(id, capacity)
    {
        public override void Reserve(Reservation reservation)
        {
            TimeTable += reservation;
            TimeTable += new Reservation(reservation.End, cleaningTime, Id, "takarítás");
        }

        public override string ToString() =>
            $"{Id} (takarítási idő: {cleaningTime} perc):\nFoglalt időpontok:\n{TimeTable}";
    }
}
