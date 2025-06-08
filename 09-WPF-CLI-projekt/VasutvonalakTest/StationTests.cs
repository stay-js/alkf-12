using VasutvonalakLib;

namespace VasutvonalakTest
{
    public class StationTests
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
        public void ConstructorHungarianStationShouldSetCountryToH()
        {
            var station = new Station("100\tBudapest\tStation\t\t1");

            Assert.Multiple(() =>
            {
                Assert.That(station.Id, Is.EqualTo(100));
                Assert.That(station.Name, Is.EqualTo("Budapest"));
                Assert.That(station.Type, Is.EqualTo("Station"));
                Assert.That(station.Country, Is.EqualTo("H"));
                Assert.That(station.Active, Is.True);
            });
        }

        [Test]
        public void ConstructorForeignStationShouldKeepOriginalCountry()
        {
            var station = new Station("101\tVienna\tStation\tA\t1");

            Assert.Multiple(() =>
            {
                Assert.That(station.Id, Is.EqualTo(101));
                Assert.That(station.Name, Is.EqualTo("Vienna"));
                Assert.That(station.Type, Is.EqualTo("Station"));
                Assert.That(station.Country, Is.EqualTo("A"));
                Assert.That(station.Active, Is.True);
            });
        }

        [Test]
        public void ConstructorInactiveStationShouldSetActiveFalse()
        {
            var station = new Station("102\tInactive\tStation\t\t0");

            Assert.That(station.Active, Is.False);
        }

        [Test]
        public void GetDistanceWithDataStoreInitializedShouldReturnCorrectDistance()
        {
            File.WriteAllLines("input/vonal.txt", ["Header", "1\t0\t1"]);
            File.WriteAllLines("input/allomas.txt", ["Header", "100\tBudapest\tStation\t\t1"]);
            File.WriteAllLines("input/hely.txt", ["Header", "1\t1\t100\t25"]);
            DataStore.Initialize();

            var station = new Station("100\tBudapest\tStation\t\t1");

            Assert.That(station.GetDistance("1"), Is.EqualTo(25));
        }

        [Test]
        public void GetDistanceWithNonExistentLineOrStationShouldReturnZero()
        {
            File.WriteAllLines("input/vonal.txt", ["Header", "1\t0\t1"]);
            File.WriteAllLines("input/allomas.txt", ["Header", "100\tBudapest\tStation\t\t1"]);
            File.WriteAllLines("input/hely.txt", ["Header"]);
            DataStore.Initialize();

            var station = new Station("100\tBudapest\tStation\t\t1");

            Assert.That(station.GetDistance("999"), Is.EqualTo(0));
        }
    }
}
