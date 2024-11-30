namespace Viragkoteszet_Lib
{
    public class FeladatLista
    {
        private readonly Termek[] _feladatok;

        public Termek[] Feladatok => _feladatok;

        public FeladatLista() : this([]) { }

        private FeladatLista(Termek[] tasks) => _feladatok = tasks;

        public static FeladatLista operator +(FeladatLista previous, Termek product)
        {
            var current = new Termek[previous._feladatok.Length + 1];
            previous._feladatok.CopyTo(current, 0);
            current[previous._feladatok.Length] = product;

            return new FeladatLista(current);
        }
    }
}
