using System.Globalization;

namespace CsevegesLib
{
    public class Chat
    {
        private const string DATE_FORMAT = "yy.MM.dd-HH:mm:ss";

        public DateTime Start { get; }
        public DateTime End { get; }
        public string Sender { get; }
        public string Reciever { get; }

        public TimeSpan Duration => End - Start;

        public Chat(string input)
        {
            string[] parts = input.Split(';');

            Start = ParseDate(parts[0]);
            End = ParseDate(parts[1]);
            Sender = parts[2];
            Reciever = parts[3];
        }

        public override string ToString() => $"{FormatDate(Start)} --> {FormatDate(End)}";

        private static DateTime ParseDate(string input) =>
            DateTime.ParseExact(input, DATE_FORMAT, CultureInfo.InvariantCulture);

        public static string FormatDate(DateTime date) => date.ToString(DATE_FORMAT);
    }
}
