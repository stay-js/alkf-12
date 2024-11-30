namespace Viragkoteszet_Lib
{
    public class Katalogus(IEnumerable<string> lines)
    {
        private readonly List<Alapanyag> _alapanyagok = lines.Select(line =>
        {
            string[] parts = line.Split(';');
            return new Alapanyag(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
        }).ToList();

        public Alapanyag this[string azonosito] => _alapanyagok.First(a => a.Azonosito == azonosito);
    }
}
