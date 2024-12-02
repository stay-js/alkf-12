namespace Jatekgyar_Lib
{
    public abstract class Jatek(string azonosito, string tipus, string megnevezes, GyartasAdatok gyartasAdatok) : IJatek
    {
        public string Azonosito { get; } = azonosito;
        public string Tipus { get; } = tipus;
        public string Megnevezes { get; } = megnevezes;

        protected readonly GyartasAdatok _gyartasAdatok = gyartasAdatok;

        public abstract int ElkeszitesiIdo { get; }

        public override string ToString() => Megnevezes;
    }
}
