namespace Celeb_Lib
{
    public class Person
    {
        public string Name { get; init; }
        public string Job { get; init; }
        public string Nationality { get; init; }
        public bool WorldFamous { get; init; }
        public Gender Gender { get; init; }

        public Person(string input)
        {
            string[] parts = input.Split(';');

            Name = parts[0];
            Job = parts[1];
            Nationality = parts[2];
            WorldFamous = parts[3] == "igen";
            Gender = parts[4] == "férfi" ? Gender.Male : Gender.Female;
        }
    }
}
