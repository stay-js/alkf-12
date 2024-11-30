namespace Viragkoteszet_Lib
{
    public class Termekek(IEnumerable<string> lines, Katalogus katalogus)
    {
        private readonly List<Termek> _termekek = lines.Select(line =>
        {
            string[] parts = line.Split(';');

            return new Termek(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                parts[3..].Chunk(2).ToDictionary(x => x[0], x => int.Parse(x[1])),
                katalogus
                );

        }).ToList();

        public Termek? this[int azonosito] => _termekek.Find(x => x.Azonosito == azonosito);

        public override string ToString() => "\t- " + string.Join("\n\t- ", _termekek);
    }
}
