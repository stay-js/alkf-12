using VasutvonalakLib;

namespace VasutvonalakTest
{
    public class LocationTests
    {
        [Test]
        public void ConstructorValidInputShouldParseCorrectly()
        {
            var location = new Location("1\tL001\t100\t50");

            Assert.Multiple(() =>
            {
                Assert.That(location.Id, Is.EqualTo(1));
                Assert.That(location.LineId, Is.EqualTo("L001"));
                Assert.That(location.StationId, Is.EqualTo(100));
                Assert.That(location.Distance, Is.EqualTo(50));
            });
        }

        [Test]
        public void ConstructorZeroDistanceShouldParseCorrectly()
        {
            var location = new Location("2\tL002\t101\t0");

            Assert.Multiple(() =>
            {
                Assert.That(location.Id, Is.EqualTo(2));
                Assert.That(location.LineId, Is.EqualTo("L002"));
                Assert.That(location.StationId, Is.EqualTo(101));
                Assert.That(location.Distance, Is.EqualTo(0));
            });
        }
    }
}
