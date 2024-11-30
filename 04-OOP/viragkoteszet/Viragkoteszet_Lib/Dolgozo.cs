namespace Viragkoteszet_Lib
{
    public abstract class Dolgozo(int azonosito, string nev)
    {

        public int Azonosito { get; } = azonosito;
        public string Nev { get; } = nev;

        public abstract double Gyakorlottsag { get; }
        public abstract int MunkaraForditottIdo { get; }

        protected FeladatLista _feladatok = new();

        public virtual void FeladatHozzaadasa(Termek product) => _feladatok += product;

        public override string ToString() => $"{Nev} ({MunkaraForditottIdo} perc)";
    }
}
