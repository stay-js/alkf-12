namespace SzepsegLib
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Profession(string line)
        {
            string[] parts = line.Split(';');

            Id = int.Parse(parts[0]);
            Name = parts[1];
        }

        public override string ToString() => Name;
    }
}
