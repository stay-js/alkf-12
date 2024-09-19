namespace TesztKiertekeles_Lib
{
    public class Result
    {
        private const int MAX_SCORE = 25;
        private const double PASSING_PERCENTAGE = .4;

        public string? Name { get; init; }
        public int?[] Score { get; init; }

        public Result(string input)
        {
            string[] parts = input.Split(';');

            Name = string.IsNullOrWhiteSpace(parts[0]) ? null : parts[0];
            Score = parts[1..]
                .Select(x => int.TryParse(x, out int value) ? value : (int?)null)
                .ToArray();
        }

        public int Total => Score.Sum() ?? 0;

        public double Percentage => (double)Total / (double)MAX_SCORE;

        public bool Passed => Percentage >= PASSING_PERCENTAGE;

        public override string ToString()
        {
            return $"1. feladat: {(Score[0] is null ? "-" : $"{Score[0]} pont")}" +
                $"\n2. feladat: {(Score[1] is null ? "-" : $"{Score[1]} pont")}" +
                $"\n3. feladat: {(Score[2] is null ? "-" : $"{Score[2]} pont")}" +
                $"\n4. feladat: {(Score[3] is null ? "-" : $"{Score[3]} pont")}" +
                $"\n5. feladat: {(Score[4] is null ? "-" : $"{Score[4]} pont")}" +
                $"\nÖsszesen: {Total} pont";
        }

        public bool SubmittedEmpty => Name is not null && Array.TrueForAll(Score, x => x is null);
    }
}
