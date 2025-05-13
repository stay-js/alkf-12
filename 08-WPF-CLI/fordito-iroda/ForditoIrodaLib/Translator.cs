namespace ForditoIrodaLib
{
    public class Translator
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int LanguageId { get; init; }
        public int TranslationFee { get; init; }
        public int DailyPages { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }

        public Translator(string line)
        {
            string[] parts = line.Split(';');

            Id = int.Parse(parts[0]);
            Name = parts[1];
            LanguageId = int.Parse(parts[2]);
            TranslationFee = int.Parse(parts[3]);
            DailyPages = int.Parse(parts[4]);
            PhoneNumber = parts[5];
            Email = parts[6];
        }

        public int OrderCount => DataStore
            .Instance?
            .Orders
            .Count(x => x.TranslatorId == Id) ?? 0;

        public int Earnings => DataStore
            .Instance?
            .Orders
            .Where(x => x.TranslatorId == Id)
            .Sum(x => x.Cost) ?? 0;

        public override string ToString() => $"{Name} ({DataStore
            .Instance?
            .Languages
            .FirstOrDefault(x => x.Id == LanguageId)?
            .Name})";
    }
}
