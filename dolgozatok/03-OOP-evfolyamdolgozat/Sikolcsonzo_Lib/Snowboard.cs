namespace Sikolcsonzo_Lib
{
    internal class Snowboard(string azonosito, string leiras, int meret, bool cipovel)
        : Sporteszkoz(azonosito, leiras, meret)
    {
        private const int ELSO_NAP = 9_000;
        private const int UTANA = 3_500;

        private const int ELSO_NAP_CIPOVEL = 13_000;
        private const int UTANA_CIPOVEL = 4_500;

        public bool Cipovel { get; } = cipovel;

        public override int Bevetel() => _foglalas.FoglaltIdoszakok
            .Sum(x => Cipovel
                ? ELSO_NAP_CIPOVEL + (x.NapokSzama - 1) * UTANA_CIPOVEL
                : ELSO_NAP + (x.NapokSzama - 1) * UTANA);

        public override string ToString()
        {
            return $"{Leiras}{(Cipovel ? ", cipővel" : "")}: {FoglaltNapokSzama} nap kölcsönzés, " +
                $"a várható bevétel: {Bevetel()} Ft\n{_foglalas}";
        }
    }
}
