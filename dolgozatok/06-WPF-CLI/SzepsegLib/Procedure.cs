using System.Globalization;

namespace SzepsegLib
{
    public class Procedure
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int GuestId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int Price { get; set; }

        public Procedure(string line)
        {
            string[] parts = line.Split(';');

            var cultureInfo = new CultureInfo("hu-HU");

            Id = int.Parse(parts[0]);
            WorkerId = int.Parse(parts[1]);
            GuestId = int.Parse(parts[2]);
            Date = DateOnly.Parse(parts[3], cultureInfo);
            Time = TimeOnly.Parse(parts[4], cultureInfo);
            Price = int.Parse(parts[5]);
        }
    }
}
