namespace F1_Lib
{
    public class Results(IEnumerable<string> lines)
    {
        private readonly List<Result> _results = lines.Skip(1).Select(line => new Result(line)).ToList();

        public IEnumerable<Result> FilterByLastName(string lastName) => _results
            .Where(x =>
                string.Equals(x.Name.Split(' ').Last(), lastName, StringComparison.CurrentCultureIgnoreCase))
            .DistinctBy(x => x.Name)
            .OrderBy(x => x.Birth);

        public IEnumerable<string> Winners => _results
            .Where(x => x.Place == 1)
            .Select(x => x.Name)
            .Distinct()
            .Order();

        public int? AgeAtFirstRace(string name) => _results
                .Where(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase))
                .MinBy(x => x.Date)?
                .Age;

        public IEnumerable<(string?, int)> TopErrorsByCarType(int amount, string car) => _results
            .Where(x => x.Error is not null)
            .Where(x => string.Equals(x.Car, car, StringComparison.CurrentCultureIgnoreCase))
            .GroupBy(x => x.Error)
            .Select(x => (x.Key, x.Count()))
            .OrderByDescending(x => x.Item2)
            .Take(amount);

        public int CountDriversWithoutATeam => _results
            .Where(x => x.Team is null)
            .DistinctBy(x => x.Name)
            .Count();

        public IEnumerable<string> DebuedAfter(string location)
        {
            var firstGP = _results
                .Where(x => string.Equals(x.Location, location, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(x => x.Date)
                .FirstOrDefault();

            if (firstGP is null) return [];

            return _results
                .Where(x => x.Date > firstGP.Date)
                .Select(x => x.Nationality)
                .Distinct()
                .OrderBy(x => x);
        }

        public IEnumerable<(int, IEnumerable<Result>)> TopDrivers(int amount, string location) => _results
            .Where(x => string.Equals(x.Location, location, StringComparison.CurrentCultureIgnoreCase))
            .Where(x => x.Place is not null)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.Place)
            .GroupBy(x => x.Date.Year)
            .Select(x => (x.Key, x.Take(amount)));
    }
}
