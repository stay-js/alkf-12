namespace ForditoIrodaLib
{
    public class Language
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public Language(string line)
        {
            string[] parts = line.Split(';');

            Id = int.Parse(parts[0]);
            Name = parts[1];
        }
    }
}
