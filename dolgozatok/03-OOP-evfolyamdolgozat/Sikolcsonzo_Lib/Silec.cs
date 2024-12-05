namespace Sikolcsonzo_Lib
{
    public class Silec(string azonosito, string leiras, int meret)
        : Sporteszkoz(azonosito, leiras, meret)
    {
        private const int ELSO_NAP = 8_000;
        private const int UTANA = 3_000;
        private const double KEDVEZMENY = 0.1;

        public override int Bevetel() => _foglalas.FoglaltIdoszakok.Sum(x =>
            {
                int alapBevetel = ELSO_NAP + ((x.NapokSzama - 1) * UTANA);
                return x.NapokSzama <= 7 ? alapBevetel : (int)(alapBevetel * (1 - KEDVEZMENY));
            });

        public override string ToString() =>
            $"{Leiras}: {FoglaltNapokSzama} nap kölcsönzés, a várható bevétel: {Bevetel()} Ft\n{_foglalas}";
    }
}
