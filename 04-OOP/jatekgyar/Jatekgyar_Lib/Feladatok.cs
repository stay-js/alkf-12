namespace Jatekgyar_Lib
{
    public class Feladatok
    {
        private readonly Feladat[] _feladatok;

        public IEnumerable<Feladat> FeladatLista => _feladatok;

        public Dictionary<string, int> DarabSzamok => _feladatok
            .GroupBy(x => x.Jatek.Megnevezes)
            .ToDictionary(x => x.Key, x => x.Sum(y => y.Darab));

        private Feladatok(Feladat[] feladatok) => _feladatok = feladatok;

        public Feladatok() : this([]) { }

        public static Feladatok operator +(Feladatok feladatok, Feladat feladat)
        {
            var newFeladatok = new Feladat[feladatok._feladatok.Length + 1];
            feladatok._feladatok.CopyTo(newFeladatok, 0);
            newFeladatok[feladatok._feladatok.Length] = feladat;

            return new Feladatok(newFeladatok);
        }

        public override string ToString() => "\t"
            + string.Join("\n\t", _feladatok.Select(x => x.ToString()));
    }
}
