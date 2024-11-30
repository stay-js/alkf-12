namespace Viragkoteszet_Lib
{
    public class Termek(int azonosito, string tipus, string megnevezes, Dictionary<string, int> alapanyagok, Katalogus katalogus) : ITermek
    {
        public int Azonosito { get; } = azonosito;
        public string Tipus { get; } = tipus;
        public string Megnevezes { get; } = megnevezes;

        private readonly Dictionary<Alapanyag, int> _alapanyagok =
            alapanyagok.ToDictionary(x => katalogus[x.Key], x => x.Value);

        public int ElkeszitesiIdo => _alapanyagok.Sum(x => x.Key.ElkeszitesiIdo * x.Value);
        public int Ar => _alapanyagok.Sum(x => x.Key.Ar * x.Value);

        public override string ToString() => $"{Megnevezes} - {Tipus} ({Ar} Ft)";
    }
}
