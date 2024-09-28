namespace Szalag_Lib
{
    public class Box
    {
        public int StartTime { get; set; }
        public int StartPoint { get; set; }
        public int EndTime { get; set; }
        public int EndPoint { get; set; }
        public int TravelDistance { get; set; }
        public int Weight { get; set; }

        public Box(string input, int Length, int Speed)
        {
            string[] parts = input.Split();

            StartTime = int.Parse(parts[0]);
            StartPoint = int.Parse(parts[1]);
            EndPoint = int.Parse(parts[2]);
            Weight = int.Parse(parts[3]);

            TravelDistance = EndPoint < StartPoint
                ? Length - StartPoint + EndPoint
                : EndPoint - StartPoint;

            EndTime = StartTime + TravelDistance * Speed;
        }
    }
}
