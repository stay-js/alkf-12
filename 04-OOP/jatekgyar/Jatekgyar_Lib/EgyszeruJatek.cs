namespace Jatekgyar_Lib
{
    public sealed class EgyszeruJatek(
        string azonosito,
        string tipus,
        string nev,
        GyartasAdatok gyartasAdatok
        ) : Jatek(azonosito, tipus, nev, gyartasAdatok)
    {
        public override int ElkeszitesiIdo => _gyartasAdatok[Tipus].ElkeszitesiIdo;

        public override string ToString() => Nev;
    }
}
