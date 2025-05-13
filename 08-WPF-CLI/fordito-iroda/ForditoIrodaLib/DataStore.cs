namespace ForditoIrodaLib
{
    public class DataStore
    {
        private readonly List<Language> _languages;
        private readonly List<Translator> _translators;
        private readonly List<Order> _orders;

        public IEnumerable<Language> Languages => _languages;
        public IEnumerable<Translator> Translators => _translators;
        public IEnumerable<Order> Orders => _orders;

        private DataStore()
        {
            _languages = File
                .ReadAllLines("input/nyelv.csv")
                .Skip(1)
                .Select(line => new Language(line))
                .ToList();

            _translators = File
                .ReadAllLines("input/fordito.csv")
                .Skip(1)
                .Select(line => new Translator(line))
                .ToList();

            _orders = File
                .ReadAllLines("input/megrendeles.csv")
                .Skip(1)
                .Select(line => new Order(line))
                .ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void Initialize()
        {
            if (Instance is not null)
                throw new InvalidOperationException("DataStore is already initialized.");

            Instance = new DataStore();
        }
    }
}
