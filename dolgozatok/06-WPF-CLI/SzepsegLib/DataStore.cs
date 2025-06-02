namespace SzepsegLib
{
    public class DataStore
    {
        private readonly List<Guest> _guests;
        private readonly List<Procedure> _procedures;
        private readonly List<Profession> _professions;
        private readonly List<Worker> _workers;

        public IEnumerable<Guest> Guests => _guests;
        public IEnumerable<Procedure> Procedures => _procedures;
        public IEnumerable<Profession> Professions => _professions;
        public IEnumerable<Worker> Workers => _workers;

        public static DataStore? Instance { get; set; }

        private DataStore()
        {
            _guests = File
                .ReadAllLines("input/vendegek.csv")
                .Skip(1)
                .Select(line => new Guest(line))
                .ToList();

            _procedures = File
                .ReadAllLines("input/kezelesek.csv")
                .Skip(1)
                .Select(line => new Procedure(line))
                .ToList();

            _professions = File
                .ReadAllLines("input/szakmak.csv")
                .Skip(1)
                .Select(line => new Profession(line))
                .ToList();

            _workers = File
                .ReadAllLines("input/alkalmazottak.csv")
                .Skip(1)
                .Select(line => new Worker(line))
                .ToList();
        }

        public static void Initialize()
        {
            if (Instance is not null)
                throw new InvalidOperationException("DataStore is already initialized!");

            Instance = new DataStore();
        }

        public static int? GetEariningsByName(string name) => Instance?
            .Workers
            .FirstOrDefault(x => x.Name == name)?
            .Earnings;
    }
}
