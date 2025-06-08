using VasutvonalakLib;

namespace VasutvonalakTest
{
    public class LineTests
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
        public void ConstructorActiveRailwayShouldParseCorrectly()
        {
            var line = new Line("1\t0\t1");

            Assert.Multiple(() =>
            {
                Assert.That(line.Id, Is.EqualTo("1"));
                Assert.That(line.LightRailway, Is.False);
                Assert.That(line.Active, Is.True);
            });
        }

        [Test]
        public void ConstructorInactiveLightRailwayShouldParseCorrectly()
        {
            var line = new Line("2\t1\t0");

            Assert.Multiple(() =>
            {
                Assert.That(line.Id, Is.EqualTo("2"));
                Assert.That(line.LightRailway, Is.True);
                Assert.That(line.Active, Is.False);
            });
        }


        [Test]
        public void GetLengthWithDataStoreUninitializedShouldThrowDataStoreUninitializedException()
        {
            var line = new Line("1\t0\t1");

            Assert.Throws<DataStoreUninitializedException>(() => line.GetLength());
        }

        [Test]
        public void GetLengthWithLocationsShouldReturnMaxDistance()
        {
            InitializeDataStore();

            var line = new Line("1\t0\t1");

            Assert.That(line.GetLength(), Is.EqualTo(50));
        }

        [Test]
        public void GetLengthWithNoLocationsShouldReturnZero()
        {
            File.WriteAllLines("input/vonal.txt", ["Header", "1\t0\t1"]);
            File.WriteAllLines("input/allomas.txt", ["Header", "100\tBudapest\tStation\t\t1"]);
            File.WriteAllLines("input/hely.txt", ["Header"]);
            DataStore.Initialize();

            var line = new Line("999\t0\t1");

            Assert.That(line.GetLength(), Is.EqualTo(0));
        }

        [Test]
        public void ContactsForeignStationsWithForeignStationShouldReturnTrue()
        {
            InitializeDataStore();

            var line = new Line("1\t0\t1");

            Assert.That(line.ContactsForeignStations, Is.True);
        }

        [Test]
        public void ContactsForeignStationsWithOnlyHungarianStationsShouldReturnFalse()
        {
            File.WriteAllLines("input/vonal.txt", ["Header", "2\t0\t1"]);
            File.WriteAllLines("input/allomas.txt", [
                "Header",
                "100\tBudapest\tStation\t\t1",
                "101\tSzeged\tStation\t\t1"
            ]);
            File.WriteAllLines("input/hely.txt", [
                "Header",
                "1\t2\t100\t0",
                "2\t2\t101\t30"
            ]);
            DataStore.Initialize();

            var line = new Line("2\t0\t1");

            Assert.That(line.ContactsForeignStations, Is.False);
        }

        [Test]
        public void GetStationsWithDataStoreUninitializedShouldThrowDataStoreUninitializedException()
        {
            var line = new Line("1\t0\t1");

            Assert.Throws<DataStoreUninitializedException>(() => line.GetStations().ToList());
        }

        [Test]
        public void GetStationsWithValidLineShouldReturnCorrectStations()
        {
            InitializeDataStore();

            var line = new Line("1\t0\t1");

            var stations = line.GetStations().ToList();

            Assert.That(stations, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                Assert.That(stations.Any(s => s.Name == "Budapest"), Is.True);
                Assert.That(stations.Any(s => s.Name == "Vienna"), Is.True);
            });
        }

        private static void InitializeDataStore()
        {
            File.WriteAllLines("input/vonal.txt", ["Header", "1\t0\t1"]);
            File.WriteAllLines("input/allomas.txt", [
                "Header",
                "100\tBudapest\tStation\t\t1",
                "101\tVienna\tStation\tA\t1"
            ]);
            File.WriteAllLines("input/hely.txt", [
                "Header",
                "1\t1\t100\t0",
                "2\t1\t101\t50"
            ]);

            DataStore.Initialize();
        }
    }
}
