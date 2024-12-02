namespace Jatekgyar_Lib
{
    public abstract class Jatek(string azonosito, string tipus, string nev, GyartasAdatok gyartasAdatok) : IJatek
    {
        public string Azonosito { get; } = azonosito;
        public string Tipus { get; } = tipus;
        public string Nev { get; } = nev;


        protected readonly GyartasAdatok _gyartasAdatok = gyartasAdatok;

        public abstract int ElkeszitesiIdo { get; }

        public override string ToString() => Nev;
    }
}
