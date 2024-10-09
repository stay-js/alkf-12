namespace MagyarKiralyok_Lib
{
    public class King
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? Nickname { get; init; }
        public int Birth { get; init; }
        public int Death { get; init; }
        public string FamilyName { get; init; }
        public int BeginningOfReign { get; init; }
        public int EndOfReign { get; init; }
        public int? CrownedAt { get; init; }

        public string FormattedName => $"{Name} {(Nickname is null ? "" : $" ({Nickname})")}";
        public int AgeAtBeginningOfReign => BeginningOfReign - Birth;
        public int ReignTime => EndOfReign - BeginningOfReign;
        
        public King(string input)
        {
            string[] parts = input.Split(';');

            Id = int.Parse(parts[0]);
            Name = parts[1];
            Nickname = string.IsNullOrWhiteSpace(parts[2]) ? null : parts[2];
            Birth = int.Parse(parts[3]);
            Death = int.Parse(parts[4]);
            FamilyName = parts[5];
            BeginningOfReign = int.Parse(parts[6]);
            EndOfReign = int.Parse(parts[7]);
            CrownedAt = int.TryParse(parts[8], out int value) ? value : null;
        }
    }
}
