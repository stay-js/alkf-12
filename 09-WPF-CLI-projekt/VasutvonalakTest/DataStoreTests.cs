using VasutvonalakLib;

namespace VasutvonalakTest
{
    public class DataStoreTests
    {
        [SetUp]
        public void Setup()
        {
            typeof(DataStore).GetProperty("Instance")?.SetValue(null, null);

            if (Directory.Exists("input"))
                Directory.Move("input", "input_backup");

            Directory.CreateDirectory("input");
        }

        [TearDown]
        public void TearDown()
        {
            typeof(DataStore).GetProperty("Instance")?.SetValue(null, null);

            Directory.Delete("input", true);

            if (Directory.Exists("input_backup"))
                Directory.Move("input_backup", "input");
        }

        [Test]
        public void InitializeFirstCallShouldCreateInstance()
        {
            CreateTestFiles();

            DataStore.Initialize();

            Assert.That(DataStore.Instance, Is.Not.Null);
        }

        [Test]
        public void InitializeSecondCallShouldThrowDataStoreAlreadyInitializedException()
        {
            CreateTestFiles();

            DataStore.Initialize();

            Assert.Throws<DataStoreAlreadyInitializedException>(() => DataStore.Initialize());
        }

        [Test]
        public void InitializeShouldLoadLinesCorrectly()
        {
            CreateTestFiles();

            DataStore.Initialize();
            Assert.That(DataStore.Instance, Is.Not.Null);

            var lines = DataStore.Instance.Lines.ToList();

            Assert.That(lines, Has.Count.EqualTo(3));

            Assert.Multiple(() =>
            {
                Assert.That(lines[0].Id, Is.EqualTo("1"));
                Assert.That(lines[1].Id, Is.EqualTo("2"));
                Assert.That(lines[2].Id, Is.EqualTo("3"));
            });
        }

        [Test]
        public void InitializeShouldLoadStationsCorrectly()
        {
            CreateTestFiles();

            DataStore.Initialize();
            Assert.That(DataStore.Instance, Is.Not.Null);

            var stations = DataStore.Instance.Stations.ToList();
            Assert.That(stations, Has.Count.EqualTo(4));

            Assert.Multiple(() =>
            {
                Assert.That(stations[0].Name, Is.EqualTo("Budapest"));
                Assert.That(stations[1].Name, Is.EqualTo("Szeged"));
                Assert.That(stations[2].Name, Is.EqualTo("Vienna"));
                Assert.That(stations[3].Name, Is.EqualTo("Inactive"));
            });
        }

        [Test]
        public void InitializeShouldLoadLocationsCorrectly()
        {
            CreateTestFiles();

            DataStore.Initialize();
            Assert.That(DataStore.Instance, Is.Not.Null);

            var locations = DataStore.Instance.Locations.ToList();
            Assert.That(locations, Has.Count.EqualTo(4));

            Assert.Multiple(() =>
            {
                Assert.That(locations[0].LineId, Is.EqualTo("1"));
                Assert.That(locations[1].StationId, Is.EqualTo(101));
                Assert.That(locations[2].Distance, Is.EqualTo(25));
            });
        }

        private static void CreateTestFiles()
        {
            File.WriteAllLines("input/vonal.txt", [
                "Id\tLightRailway\tActive",
                "1\t0\t1",
                "2\t1\t0",
                "3\t0\t1"
            ]);

            File.WriteAllLines("input/allomas.txt", [
                "Id\tName\tType\tCountry\tActive",
                "100\tBudapest\tStation\t\t1",
                "101\tSzeged\tStation\t\t1",
                "102\tVienna\tStation\tA\t1",
                "103\tInactive\tStation\t\t0"
            ]);

            File.WriteAllLines("input/hely.txt", [
                "Id\tLineId\tStationId\tDistance",
                "1\t1\t100\t0",
                "2\t1\t101\t50",
                "3\t2\t102\t25",
                "4\t3\t103\t75"
            ]);
        }
    }
}
