namespace Sikolcsonzo_Lib
{
    public class Foglalas
    {
        private readonly List<Berles> _foglalasok;

        public List<Berles> FoglaltIdoszakok => _foglalasok;

        private Foglalas(List<Berles> foglalasok) => _foglalasok = foglalasok;

        public Foglalas() : this([]) { }

        public bool SzabadE(DateOnly berlesKezdet, int napokSzama) =>
            !FoglaltIdoszakok.Exists(x => berlesKezdet <= x.BerlesVege
            && x.BerlesKezdet <= berlesKezdet.AddDays(napokSzama));

        public override string ToString() =>
            string.Join('\n', FoglaltIdoszakok.OrderBy(x => x.BerlesKezdet));

        public static Foglalas operator +(Foglalas elozo, Berles berles)
        {
            var jelenlegi = elozo.FoglaltIdoszakok;

            if (!elozo.SzabadE(berles.BerlesKezdet, berles.NapokSzama))
                throw new HibasFogalasException();

            jelenlegi.Add(berles);
            return new Foglalas(jelenlegi);
        }
    }
}
