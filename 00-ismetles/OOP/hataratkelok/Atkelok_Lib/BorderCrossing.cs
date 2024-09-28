namespace Atkelok_Lib
{
    public class BorderCrossing
    {
        public string Settlement { get; init; }
        public string SettlementType { get; init; }
        public string County { get; init; }
        public string BorderingSettlement { get; init; }
        public string Country { get; init; }
        public string Type { get; init; }

        public BorderCrossing(string input)
        {
            string[] parts = input.Split(';');

            Settlement = parts[0];
            SettlementType = parts[1];
            County = parts[2];
            BorderingSettlement = parts[3];
            Country = parts[4];
            Type = parts[5];
        }

        public string InfoWithoutCountry => $"{Settlement} - {BorderingSettlement}: {Type}";

        public override string ToString()
        {
            return $"{Settlement} - {BorderingSettlement} ({Country}): {Type}";
        }
    }
}
