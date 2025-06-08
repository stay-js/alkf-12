namespace VasutvonalakLib
{
    public class Location
    {
        public int Id { get; set; }
        public string LineId { get; set; }
        public int StationId { get; set; }
        public int Distance { get; set; }

        public Location(string line)
        {
            string[] parts = line.Split('\t');

            Id = int.Parse(parts[0]);
            LineId = parts[1];
            StationId = int.Parse(parts[2]);
            Distance = int.Parse(parts[3]);
        }
    }
}
