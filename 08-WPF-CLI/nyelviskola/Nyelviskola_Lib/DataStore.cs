using System.Text;
using System.Text.Json;

namespace Nyelviskola_Lib
{
    public class DataStore
    {
        private readonly List<Language> _languages;
        private readonly List<Teacher> _teachers;
        private readonly List<Lesson> _lessons;

        public IEnumerable<Language> Languages => _languages;
        public IEnumerable<Teacher> Teachers => _teachers;
        public IEnumerable<Lesson> Lessons => _lessons;

        private DataStore()
        {
            _languages = File
                .ReadAllLines("input/nyelv.csv")
                .Skip(1)
                .Select(line => new Language(line))
                .ToList();

            _teachers = File
                .ReadAllLines("input/tanar.csv")
                .Skip(1)
                .Select(line => new Teacher(line))
                .ToList();

            _lessons = File
                .ReadAllLines("input/tanitasi_alkalom.csv")
                .Skip(1)
                .Select(line => new Lesson(line))
                .ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void Initialize()
        {
            if (Instance is not null)
                throw new InvalidOperationException("DataStore is already initialized.");

            Instance = new DataStore();
        }

        private static readonly JsonSerializerOptions _JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private static void ExportToJson<T>(IEnumerable<T> items, string fileName)
        {
            string json = JsonSerializer.Serialize(items, _JsonOptions);
            File.WriteAllText(fileName, json, Encoding.UTF8);
        }

        public void ExportAllToJson()
        {
            ExportToJson(_languages, "nyelv.json");
            ExportToJson(_teachers, "tanar.json");
            ExportToJson(_lessons, "tanitasi_alkalom.json");
        }
    }
}
