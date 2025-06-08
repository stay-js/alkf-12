namespace VasutvonalakLib
{
    public class Line
    {
        public string Id { get; set; }
        public bool LightRailway { get; set; }
        public bool Active { get; set; }

        public Line(string line)
        {
            string[] parts = line.Split('\t');

            Id = parts[0];
            LightRailway = parts[1] != "0";
            Active = parts[2] != "0";
        }

        public int GetLength()
        {
            if (DataStore.Instance is null)
                throw new DataStoreUninitializedException();

            var distances = DataStore
                .Instance
                .Locations
                .Where(x => x.LineId == Id)
                .Select(x => x.Distance);

            return distances.Any() ? distances.Max() : 0;
        }

        public bool ContactsForeignStations => GetStations().Any(x => x.Country != "H");

        public IEnumerable<Station> GetStations()
        {
            if (DataStore.Instance is null)
                throw new DataStoreUninitializedException();

            var stationIds = DataStore
                .Instance
                .Locations
                .Where(x => x.LineId == Id)
                .Select(x => x.StationId);

            return DataStore.Instance.Stations.Where(x => stationIds.Contains(x.Id));
        }

        public override string ToString() =>
            $"{Id} {(LightRailway ? "- Kisvasút " : "")}({(Active ? "Aktív" : "Inaktív")})";
    }
}
