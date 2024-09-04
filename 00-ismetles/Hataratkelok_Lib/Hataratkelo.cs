namespace Hataratkelok_Lib
{
    public class Hataratkelo
    {
        public string Telepules { get; init; }
        public string TelepulesTipus { get; init; }
        public string Megye { get; init; }
        public string SzomszedTelepules { get; init; }
        public string Orszag { get; init; }
        public string Tipus { get; init; }

        public Hataratkelo(string input)
        {
            string[] parts = input.Split(';');

            Telepules = parts[0];
            TelepulesTipus = parts[1];
            Megye = parts[2];
            SzomszedTelepules = parts[3];
            Orszag = parts[4];
            Tipus = parts[5];
        }

        public string InfoWithoutCountry => $"{Telepules} - {SzomszedTelepules}: {Tipus}";

        public override string ToString()
        {
            return $"{Telepules} - {SzomszedTelepules} ({Orszag}): {Tipus}";
        }
    }
}