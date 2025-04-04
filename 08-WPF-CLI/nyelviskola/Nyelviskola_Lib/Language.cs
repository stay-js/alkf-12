namespace Nyelviskola_Lib
{
    public class Language
    {
        public int ID { get; init; }
        public string Name { get; init; }

        public Language(string line)
        {
            string[] parts = line.Split(';');

            ID = int.Parse(parts[0]);
            Name = parts[1];
        }

        public override string ToString() => Name;
    }
}
