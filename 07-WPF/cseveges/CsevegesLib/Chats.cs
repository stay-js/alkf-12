namespace CsevegesLib
{
    public class Chats(string[] lines)
    {
        private readonly IEnumerable<Chat> _chats = lines
            .Skip(1)
            .Select(x => new Chat(x));

        public int Count => _chats.Count();
        public Chat Longest => _chats.OrderByDescending(x => x.Duration).First();

        public IEnumerable<string> Senders => _chats
            .Select(x => x.Sender)
            .Distinct()
            .Order();

        public IEnumerable<string> Recievers => _chats
           .Select(x => x.Reciever)
           .Distinct()
           .Order();

        public IEnumerable<Chat> GetBySenderAndReciever(string sender, string reciever) => _chats
            .Where(x => x.Sender == sender && x.Reciever == reciever);

        public IEnumerable<string> DidntTalkToAnyone(IEnumerable<string> names) => names
            .Where(x => !Senders.Contains(x) && !Recievers.Contains(x));

        public TimeSpan TimeSpentChatting(string name) => TimeSpan.FromTicks(_chats
            .Where(x => x.Sender == name || x.Reciever == name)
            .Sum(x => x.Duration.Ticks));

        public (DateTime Start, DateTime End, TimeSpan Duration) LongestSilentPeriod()
        {
            var start = DateTime.Now;
            var end = DateTime.Now;
            var longestSilentPeriod = TimeSpan.Zero;

            var sortedChats = _chats
                .Where(x => x.Start > new DateTime(2019, 09, 27, 14, 59, 59, DateTimeKind.Utc))
                .OrderBy(x => x.Start)
                .ToList();

            for (int i = 1; i < sortedChats.Count; i++)
            {
                var silentPeriod = sortedChats[i].Start - sortedChats[i - 1].End;
                
                if (silentPeriod > longestSilentPeriod)
                {
                    start = sortedChats[i - 1].End;
                    end = sortedChats[i].Start;
                    longestSilentPeriod = silentPeriod;
                }
            }

            return (start, end, longestSilentPeriod);
        }
    }
}
