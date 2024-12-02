namespace Jatekgyar_Lib
{
    public sealed class EgyszeruJatek(
        string azonosito,
        string tipus,
        string megnevezes,
        GyartasAdatok gyartasAdatok
        ) : Jatek(azonosito, tipus, megnevezes, gyartasAdatok)
    {
        public override int ElkeszitesiIdo => _gyartasAdatok[Tipus].ElkeszitesiIdo;

        public override string ToString() => Megnevezes;
    }
}
