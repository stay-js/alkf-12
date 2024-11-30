namespace Viragkoteszet_Lib
{
    public class Gyakornok(int azonosito, string nev, int[] termekek) : Dolgozo(azonosito, nev)
    {
        public override double Gyakorlottsag => new[] { 70, 80, 90 }[Random.Shared.Next(3)];
        public override int MunkaraForditottIdo =>
            _feladatok.Feladatok.Sum(x => (int)Math.Round(x.ElkeszitesiIdo * (1 + (1 - (Gyakorlottsag / 100)))));

        private readonly int[] _elkeszithetoTermekek = termekek;

        public override void FeladatHozzaadasa(Termek product)
        {
            if (!_elkeszithetoTermekek.Contains(product.Azonosito))
                throw new HibasFeladatException();

            _feladatok += product;
        }

        public override string ToString() => $"{Nev} - gyakornok ({MunkaraForditottIdo} perc) - {string.Join(", ", _elkeszithetoTermekek)}";
    }
}
