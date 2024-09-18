namespace Eloadasok_Lib
{
    public class Performances(IEnumerable<string> lines)
    {
        private readonly List<Performance> _performances = lines
            .Skip(1)
            .Select(x => new Performance(x))
            .ToList();

        public int Count => _performances.Count;

        public Performance? MostExpensive => _performances.MaxBy(x => x.Category1Price);

        public Performance? LeastAvailableTickets => _performances.MinBy(x => x.AvailableTickets);

        public IEnumerable<Performance> OrderedByTicketsSold => _performances
            .OrderByDescending(x => x.TotalSold);

        public IEnumerable<(string, int)> IncomePerPerformance => _performances
            .GroupBy(x => x.Title)
            .Select(g => (g.Key, g.Sum(x => x.Income)));

        public IEnumerable<string> PerformedMoreThanOnce => _performances
            .GroupBy(x => x.Title)
            .Where(g => g.Count() > 1)
            .Select(x => x.Key);

        public IEnumerable<Performance> CheapestByCategory2(int amount) => _performances
            .OrderBy(x => x.Category2Price)
            .Take(amount);

        public IEnumerable<string> Titles => _performances
            .Select(x => x.Title)
            .Distinct()
            .Order();
    }
}
