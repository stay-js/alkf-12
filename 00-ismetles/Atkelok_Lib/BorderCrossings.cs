namespace Atkelok_Lib
{
    public class BorderCrossings(IEnumerable<string> lines)
    {
        private readonly List<BorderCrossing> _borderCrossings = lines
            .Skip(1)
            .Select(line => new BorderCrossing(line))
            .ToList();

        public int Count => _borderCrossings.Count;

        public int CountByType(string type) => _borderCrossings
            .Count(x => string.Equals(x.Type, type, StringComparison.CurrentCultureIgnoreCase));

        public IEnumerable<BorderCrossing> FilterBySettlementType(string settlementType) => _borderCrossings
            .Where(x => string.Equals(x.SettlementType, settlementType, StringComparison.CurrentCultureIgnoreCase));

        public int CountCitiesTo(string country) => _borderCrossings
            .Count(x => string.Equals(x.Country, country, StringComparison.CurrentCultureIgnoreCase)
            && x.SettlementType.Contains("város"));

        public string FirstCrossingTo(string country) => _borderCrossings
            .Where(x => string.Equals(x.Country, country, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Settlement)
            .Order()
            .First();

        public IEnumerable<string> BorderingCountries => _borderCrossings
            .Select(x => x.Country)
            .Distinct()
            .Order();

        public IEnumerable<string> CitiesWithRailwayAndRoadCrossing => _borderCrossings
            .GroupBy(x => x.Settlement)
            .Where(g => g.Any(x => x.Type == "vasúti") && g.Any(x => x.Type == "közúti"))
            .Select(x => x.Key)
            .Order();

        public IEnumerable<(string, int)> CountriesWithCount => _borderCrossings
            .GroupBy(x => x.Country)
            .Select(x => (x.Key, x.Count()));

        public IEnumerable<BorderCrossing> FilterByCounty(string county) => _borderCrossings
            .Where(x => string.Equals(x.County, county, StringComparison.CurrentCultureIgnoreCase));
    }
}
