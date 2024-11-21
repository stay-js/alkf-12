namespace FoglalasLib
{
    public class RoomRegistration(IEnumerable<string> lines)
    {
        public List<Room> Rooms { get; set; } = lines.Select<string, Room>(line =>
        {
            string[] parts = line.Split(';');

            if (parts[0] == "s")
                return new SpecialRoom(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));

            return new BasicRoom(parts[1], int.Parse(parts[2]));
        }).ToList();

        public IEnumerable<string> RoomIds => Rooms.Select(x => x.Id);

        public Room this[string id] => Rooms.Find(x => x.Id == id)
            ?? throw new ArgumentException("Nincs ilyen azonosítójú terem");

        public async Task MakeReservations(IEnumerable<Reservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                try
                {
                    this[reservation.RoomId].Reserve(reservation);
                }
                catch (Exception e)
                {
                    using StreamWriter output = new("hibak.txt", true);
                    await output.WriteLineAsync($"{reservation} - {e.Message}");
                }
            }
        }
    }
}
