namespace TesztKiertekeles_Lib
{
    public class Result
    {
        private const int MAX_SCORE = 25;
        private const double PASSING_PERCENTAGE = .4;

        public string? Name { get; init; }
        public int? Score1 { get; init; }
        public int? Score2 { get; init; }
        public int? Score3 { get; init; }
        public int? Score4 { get; init; }
        public int? Score5 { get; init; }

        public Result(string input)
        {
            string[] parts = input.Split(';');

            Name = string.IsNullOrWhiteSpace(parts[0]) ? null : parts[0];

            Score1 = ParseNullableInt(parts[1]);
            Score2 = ParseNullableInt(parts[2]);
            Score3 = ParseNullableInt(parts[3]);
            Score4 = ParseNullableInt(parts[4]);
            Score5 = ParseNullableInt(parts[5]);
        }

        public int Total => (Score1 ?? 0) + (Score2 ?? 0) + (Score3 ?? 0) + (Score4 ?? 0) + (Score5 ?? 0);

        public double Percentage => (double)Total / (double)MAX_SCORE;

        public bool Passed => Percentage >= PASSING_PERCENTAGE;

        public override string ToString()
        {
            return $"1. feladat: {(Score1 is null ? "-" : $"{Score1} pont")}" +
                $"\n2. feladat: {(Score2 is null ? "-" : $"{Score2} pont")}" +
                $"\n3. feladat: {(Score3 is null ? "-" : $"{Score3} pont")}" +
                $"\n4. feladat: {(Score4 is null ? "-" : $"{Score4} pont")}" +
                $"\n5. feladat: {(Score5 is null ? "-" : $"{Score5} pont")}" +
                $"\nÖsszesen: {Total} pont";
        }

        public bool SubmittedEmpty => Name is not null
            && Score1 is null
            && Score2 is null
            && Score3 is null
            && Score4 is null
            && Score5 is null;

        private static int? ParseNullableInt(string? input)
        {
            return int.TryParse(input, out int value) ? value : null;
        }
    }
}
