using System.Globalization;

namespace ForditoIrodaLib
{
    public class Order
    {
        public int Id { get; init; }
        public int TranslatorId { get; init; }
        public int OrdererId { get; init; }
        public DateOnly Date { get; init; }
        public int Pages { get; init; }

        public Order(string line)
        {
            string[] parts = line.Split(';');

            Id = int.Parse(parts[0]);
            TranslatorId = int.Parse(parts[1]);
            OrdererId = int.Parse(parts[2]);
            Date = DateOnly.Parse(parts[3], new CultureInfo("hu-HU"));
            Pages = int.Parse(parts[4]);
        }

        public int Price => Pages *
            DataStore
            .Instance?
            .Translators
            .First(x => x.Id == TranslatorId)
            .TranslationPrice ?? 0;
    }
}
