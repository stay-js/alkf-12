namespace VasutvonalakLib
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }

        public Station(string line)
        {
            string[] parts = line.Split('\t');

            Id = int.Parse(parts[0]);
            Name = parts[1];
            Type = parts[2];

            // Magyarország UIC országkódja "H".
            // Forrás: https://hu.wikipedia.org/wiki/UIC_orsz%C3%A1gk%C3%B3dok_list%C3%A1ja
            // Az adatfájlban a magyarországi állomások esetén az országkód üres.
            Country = parts[3] == string.Empty ? "H" : parts[3];

            Active = parts[4] != "0";
        }

        public int GetDistance(string lineId)
        {
            return DataStore.Instance?
                .Locations
                .FirstOrDefault(x => x.LineId == lineId && x.StationId == Id)?
                .Distance ?? 0;
        }

        public override string ToString() => Name;
    }
}
