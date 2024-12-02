namespace Jatekgyar_Lib
{
    public class Feladat
    {
        const int MAX_PERC = 8 * 60;

        public Jatek Jatek { get; }
        public int Darab { get; }

        public int ElkeszitesiIdo => Jatek.ElkeszitesiIdo * Darab;

        public Feladat(Jatek jatek, int darab)
        {
            Jatek = jatek;
            Darab = darab;

            if (ElkeszitesiIdo > MAX_PERC) throw new TulSokFeladatException();
        }

        public override string ToString() =>
            $"{Jatek.Nev}: {Darab} db, elkeszítési idő: {ElkeszitesiIdo} perc";
    }
}
