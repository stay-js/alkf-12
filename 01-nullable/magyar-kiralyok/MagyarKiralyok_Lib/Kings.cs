namespace MagyarKiralyok_Lib
{
    public class Kings(IEnumerable<string> lines)
    {
        private readonly List<King> _kings = lines.Skip(1).Select(line => new King(line)).ToList();

        public IEnumerable<King> CrownedBetween(int start, int end) => _kings
            .Where(x => x.CrownedAt >= start && x.CrownedAt <= end);

        public IEnumerable<King> DistinctKings => _kings
            .DistinctBy(x => x.Name)
            .OrderByDescending(x => x.Birth);

        public IEnumerable<King> YoungKings => _kings
            .Where(x => x.AgeAtBeginningOfReign < 14)
            .OrderBy(x => x.AgeAtBeginningOfReign);

        public IEnumerable<King> LongestReign(int amount) => _kings
            .OrderByDescending(x => x.ReignTime)
            .Take(amount);

        public IEnumerable<(string, int)> Families => _kings
            .GroupBy(x => x.FamilyName)
            .Select(x => (x.Key, x.Count()))
            .OrderByDescending(x => x.Item2);

        public IEnumerable<string> RuledBeforeCrowning => _kings
            .Where(x => x.CrownedAt is null || x.BeginningOfReign < x.CrownedAt)
            .Select(x => x.Name);

        public IEnumerable<King> HasNickname => _kings
            .Where(x => x.Nickname is not null)
            .OrderByDescending(x => x.Birth);
    }
}
