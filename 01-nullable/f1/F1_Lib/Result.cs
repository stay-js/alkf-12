namespace F1_Lib
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Result
    {
        public DateOnly Date { get; init; }
        public string Location { get; init; }
        public string Name { get; init; }
        public Gender Gender { get; init; }
        public DateOnly? Birth { get; init; }
        public string Nationality { get; init; }
        public int? Place { get; init; }
        public string? Error { get; init; }
        public string? Team { get; init; }
        public string Car { get; init; }
        public string Engine { get; init; }

        public int Age => Birth is null ? 0 : Date.Year - Birth.Value.Year;

        public Result(string input)
        {
            string[] parts = input.Split(';');

            Date = DateOnly.Parse(parts[0]);
            Location = parts[1];
            Name = parts[2];
            Gender = parts[3] == "F" ? Gender.Male : Gender.Female;
            Birth = string.IsNullOrWhiteSpace(parts[4]) ? null : DateOnly.Parse(parts[4]);
            Nationality = parts[5];
            Place = int.TryParse(parts[6], out int value) ? value : null;
            Error = string.IsNullOrWhiteSpace(parts[7]) ? null : parts[7];
            Team = string.IsNullOrWhiteSpace(parts[8]) ? null : parts[8];
            Car = parts[9];
            Engine = parts[10];
        }
    }
}
