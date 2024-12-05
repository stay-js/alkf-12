namespace Sikolcsonzo_Lib
{
    public abstract class Sporteszkoz(string azonosito, string leiras, int meret)
    {
        protected Foglalas _foglalas = new();

        public string Azonosito { get; } = azonosito;
        public string Leiras { get; } = leiras;
        public int Meret { get; } = meret;

        public int FoglaltNapokSzama => _foglalas.FoglaltIdoszakok.Sum(x => x.NapokSzama);

        public Foglalas Foglalas => _foglalas;

        public void UjBerles(Berles berles) => _foglalas += berles;

        public abstract int Bevetel();

        public bool this[DateOnly nap] => _foglalas.SzabadE(nap, 0);
    }
}
