namespace Viragkoteszet_Lib
{
    public class Alapanyag(string azonosito, string nev, int ar, int elkeszitesiIdo)
    {
        public string Azonosito { get; } = azonosito;
        public string Nev { get; } = nev;
        public int Ar { get; } = ar;
        public int ElkeszitesiIdo { get; } = elkeszitesiIdo;
    }
}
