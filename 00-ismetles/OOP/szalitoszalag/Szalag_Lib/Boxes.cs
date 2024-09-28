namespace Szalag_Lib
{
    public class Boxes
    {
        private readonly List<Box> boxes;

        public Boxes(IEnumerable<string> lines)
        {
            string[] parts = lines.First().Split();

            int length = int.Parse(parts[0]);
            int speed = int.Parse(parts[1]);

            boxes = lines.Skip(1).Select(line => new Box(line, length, speed)).ToList();
        }

        public Box GetByNumber(int number) => boxes[number - 1];

        public int MaxDistance => boxes.Max(x => x.TravelDistance);

        public IEnumerable<int> IdsByTravelDistance(int distance)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].TravelDistance == distance) yield return i + 1;
            }
        }

        public int WeightOfPassingStartPoint => boxes
            .Where(x => x.StartPoint > x.EndPoint)
            .Sum(x => x.Weight);

        public IEnumerable<int> BeingTransportedAt(int time)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].StartTime <= time && time <= boxes[i].EndTime)
                    yield return i + 1;
            }
        }

        public IEnumerable<(int, int)> Weights => boxes
            .GroupBy(x => x.StartPoint)
            .Select(g => (g.Key, g.Sum(x => x.Weight)))
            .OrderBy(x => x.Key);
    }
}
