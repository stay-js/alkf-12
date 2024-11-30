namespace Viragkoteszet_Lib
{
    public class Dolgozok(IEnumerable<Dolgozo> dolgozok)
    {
        private readonly List<Dolgozo> _dolgozok = dolgozok.ToList();

        public int DolgozokSzama => _dolgozok.Count;

        public Dolgozo? this[int azonosito] => _dolgozok.Find(x => x.Azonosito == azonosito);

        public override string ToString() => "\t- " + string.Join("\n\t- ", _dolgozok);
    }
}
