namespace Eloadasok_Lib
{
    public class Performance
    {
        const int AVAILABLE_SEATS = 130;

        public string Title { get; init; }
        public int Category1Price { get; init; }
        public int Category1 { get; init; }
        public int Category2Price { get; init; }
        public int Category2 { get; init; }

        public int AvailableTickets => AVAILABLE_SEATS - (Category1 + Category2);
        public int Income => Category1 * Category1Price + Category2 * Category2Price;
        public int TotalSold => Category1 + Category2;

        public Performance(string input)
        {
            string[] parts = input.Split(';');

            Title = parts[0];
            Category1Price = int.Parse(parts[1]);
            Category1 = int.Parse(parts[2]);
            Category2Price = int.Parse(parts[3]);
            Category2 = int.Parse(parts[4]);
        }
    }
}
