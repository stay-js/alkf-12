namespace Hataratkelok_Lib
{
    public class Hataratkelok(IEnumerable<string> lines)
    {
        private readonly List<Hataratkelo> _hataratkelok = lines
            .Skip(1)
            .Select(line => new Hataratkelo(line))
            .ToList();

        public int Count => _hataratkelok.Count;

        public int CountRailwayCrossings => _hataratkelok.Count(x => x.Tipus == "vasúti");

        public IEnumerable<Hataratkelo> CitiesWithCountryRights => _hataratkelok
            .Where(x => x.TelepulesTipus == "megyei jogú város");

        public int CountCitiesTo(string country) => _hataratkelok
            .Count(x => string.Equals(x.Orszag, country, StringComparison.CurrentCultureIgnoreCase)
            && x.TelepulesTipus.Contains("város"));

        public string FirstCrossingTo(string country) => _hataratkelok
            .Where(x => string.Equals(x.Orszag, country, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => x.Telepules)
            .Order()
            .First();

        public IEnumerable<string> BorderingCountries => _hataratkelok
            .Select(x => x.Orszag)
            .Distinct()
            .Order();

        public IEnumerable<string> CitiesWithRailwayAndRoadCrossing => _hataratkelok
            .GroupBy(x => x.Telepules)
            .Where(g =>
                g.Any(x => x.Tipus == "vasúti")
                && g.Any(x => x.Tipus == "közúti"))
            .Select(x => x.Key)
            .Order();

        public IEnumerable<(string, int)> CountriesWithCount => _hataratkelok
                .GroupBy(x => x.Orszag)
                .Select(x => (x.Key, x.Count()));

        public IEnumerable<Hataratkelo> FilterByCounty(string county) => _hataratkelok
            .Where(x => x.Megye == county);
    }
}
