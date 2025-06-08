namespace VasutvonalakLib
{
    public class DataStore
    {
        private readonly List<Line> _lines;
        private readonly List<Station> _stations;
        private readonly List<Location> _locations;

        public IEnumerable<Line> Lines => _lines;
        public IEnumerable<Station> Stations => _stations;
        public IEnumerable<Location> Locations => _locations;

        private DataStore()
        {
            _lines = File
                .ReadAllLines("input/vonal.txt")
                .Skip(1)
                .Select(line => new Line(line))
                .ToList();

            _stations = File
                .ReadAllLines("input/allomas.txt")
                .Skip(1)
                .Select(line => new Station(line))
                .ToList();

            _locations = File
                .ReadAllLines("input/hely.txt")
                .Skip(1)
                .Select(line => new Location(line))
                .ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void Initialize()
        {
            if (Instance is not null)
                throw new DataStoreAlreadyInitializedException();

            Instance = new DataStore();
        }
    }
}
