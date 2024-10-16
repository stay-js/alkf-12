namespace Kifizet_Lib
{
    public class Payouts(IEnumerable<string> lines)
    {
        private readonly List<Payout> _payouts = lines.Select(x =>
            {
                string[] parts = x.Split(';');
                return (Name: parts[0], Amount: int.Parse(parts[1]));
            })
            .GroupBy(x => x.Name)
            .Select(g => new Payout(g.Key, g.Sum(x => x.Amount)))
            .ToList();

        public int this[string name] => _payouts.First(x =>
            string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase)).Amount;

        public IEnumerable<Payout> ActualPayouts => _payouts
            .OrderBy(x => x.Name)
            .Select(x => x with { Amount = RoundToNearestHundred(x.Amount) });

        public Dictionary<int, int> ChangeRequired => _payouts
            .SelectMany(x => Change(x.Amount))
            .GroupBy(x => x.Key)
            .ToDictionary(g => g.Key, g => g.Sum(i => i.Value));

        public Dictionary<string, int> ActualPayoutsWithMonogram => ActualPayouts
            .ToDictionary(x => string.Join(" ", x.Name.Split().Select(y => y[0])), x => x.Amount);

        public static int RoundToNearestHundred(int amount) => (int)Math.Round(amount / 100.0) * 100;

        private static Dictionary<int, int> Change(int amount)
        {
            Dictionary<int, int> change = [];

            int[] denominations = [20_000, 10_000, 5_000, 2_000, 1_000, 500, 200, 100];

            foreach (int denomination in denominations)
            {
                while (amount >= denomination)
                {
                    amount -= denomination;

                    if (change.ContainsKey(denomination)) change[denomination]++;
                    else change[denomination] = 1;
                }
            }

            return change;
        }
    }
}
