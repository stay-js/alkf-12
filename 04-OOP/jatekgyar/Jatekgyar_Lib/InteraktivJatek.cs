namespace Jatekgyar_Lib
{
    public sealed class InteraktivJatek(
        string azonosito,
        string tipus,
        string nev,
        IEnumerable<string> modulok,
        GyartasAdatok gyartasAdatok
        ) : Jatek(azonosito, tipus, nev, gyartasAdatok)
    {
        private readonly List<string> _modulok = modulok.ToList();

        public override int ElkeszitesiIdo => _modulok
            .Sum(x => _gyartasAdatok[TipusMeghatarozas(x)].ElkeszitesiIdo);

        private static string TipusMeghatarozas(string modul) =>
            modul.First() == 'k' ? modul : modul.First().ToString();
    }
}
