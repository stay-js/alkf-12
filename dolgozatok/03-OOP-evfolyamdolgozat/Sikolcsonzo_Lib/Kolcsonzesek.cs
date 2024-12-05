namespace Sikolcsonzo_Lib
{
    public class Kolcsonzesek(IEnumerable<string> lines)
    {
        private readonly List<Sporteszkoz> _sporteszkozok = lines
            .Select(SporteszkozFactory.Factory)
            .ToList();

        public IEnumerable<string> KolcsonozhetoEszkozok => _sporteszkozok.Select(x => x.Leiras);

        public IEnumerable<Sporteszkoz> SzabadSporteszkozok(DateOnly kezdoDatum, int napokSzama) =>
            _sporteszkozok.Where(x => x.Foglalas.SzabadE(kezdoDatum, napokSzama));

        public Sporteszkoz? this[string azonosito] => _sporteszkozok.Find(x => x.Azonosito == azonosito);

        public IEnumerable<string> SporteszkozBerles(IEnumerable<Berles> berlesek)
        {
            var errorList = new List<string>();

            foreach (var berles in berlesek)
            {
                try
                {
                    this[berles.SporteszkozID]?.UjBerles(berles);
                }
                catch (HibasFogalasException e)
                {
                    errorList.Add($"{e.Message} - {berles.BerlesKezdet} - {berles.BerlesVege} " +
                        $"{berles.Nev}, {berles.SporteszkozID}");
                }
            }

            return errorList;
        }

        public override string ToString() => string.Join('\n',
            _sporteszkozok.Where(x => x.FoglaltNapokSzama > 0));
    }
}
