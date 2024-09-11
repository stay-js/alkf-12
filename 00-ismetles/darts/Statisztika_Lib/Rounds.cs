namespace Statisztika_Lib
{
    public class Rounds(IEnumerable<string> lines)
    {
        private readonly List<Round> _rounds = lines.Select(x => new Round(x)).ToList();

        private IEnumerable<Round> Player1 => _rounds.Where(x => x.Player == 1);
        private IEnumerable<Round> Player2 => _rounds.Where(x => x.Player == 2);

        public int Count => _rounds.Count;

        public int CountThrowsByTypeAndIndex(string type, int index) =>
            _rounds.Count(x => string.Equals(x.Throws[index], type, StringComparison.CurrentCultureIgnoreCase));

        public (int, int) SectorCount(string sector) =>
            (Player1.Count(x => x.Throws.Contains(sector)),
            Player2.Count(x => x.Throws.Contains(sector)));

        public (int, int) OneEightyCount =>
            (Player1.Count(x => Array.TrueForAll(x.Throws, t => t == "T20")),
             Player2.Count(x => Array.TrueForAll(x.Throws, t => t == "T20")));
    }
}
