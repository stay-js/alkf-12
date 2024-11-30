namespace Viragkoteszet_Lib
{
    public class Viragkoto(int azonosito, string nev) : Dolgozo(azonosito, nev)
    {
        public override double Gyakorlottsag => 100;
        public override int MunkaraForditottIdo => _feladatok.Feladatok.Sum(x => x.ElkeszitesiIdo);
    }
}
