namespace Statisztika_Lib
{
    public class Round
    {
        public int Player { get; init; }
        public string[] Throws { get; init; }

        public Round(string input)
        {
            string[] parts = input.Split(';');

            Player = int.Parse(parts[0]);
            Throws = parts[1..];
        }
    }
}
