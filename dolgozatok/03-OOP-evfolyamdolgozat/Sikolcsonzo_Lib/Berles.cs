namespace Sikolcsonzo_Lib
{
    public class Berles : IBerles
    {
        public string SporteszkozID { get; init; }
        public DateOnly BerlesKezdet { get; init; }
        public int NapokSzama { get; init; }
        public string Nev { get; init; }

        public DateOnly BerlesVege => BerlesKezdet.AddDays(NapokSzama);

        public Berles(string sporteszkozId, DateOnly berelesKezdet, int napokSzama, string nev)
        {
            SporteszkozID = sporteszkozId;
            BerlesKezdet = berelesKezdet;
            NapokSzama = napokSzama;
            Nev = nev;

            if (BerlesKezdet < new DateOnly(2024, 12, 02)
                || BerlesVege > new DateOnly(2025, 04, 21))
            {
                throw new HibasDatumException();
            }
        }

        public override string ToString() => $"{BerlesKezdet} - {BerlesVege} {Nev}";
    }
}
