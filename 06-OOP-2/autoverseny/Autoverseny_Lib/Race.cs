namespace Autoverseny_Lib
{
    public class Race
    {
        private List<Driver> _drivers;
        private readonly List<Driver> _out = [];

        public List<Driver> Drivers => _drivers;
        public List<Driver> NewOrder = [];

        public int Laps { get; init; }
        public int CurrentLap { get; private set; } = 1;
        public int DriverCount => _drivers.Count;

        public string Result => $"Lap {CurrentLap} / {Laps} Result:" +
            $"\n\nOrder:\n{string.Join("\n",
                _drivers.Enumerate().Select(x => $"{x.Index + 1}. {x.Item.Name}"))}" +
            $"\n\nOut:\n{string.Join("\n", _out.Select(x => x.Name))}" +
            "\n\nPodium:\n\t- " +
            string.Join("\n\t- ",
                Drivers.Take(3).Enumerate().Select(x => $"{x.Index + 1}. {x.Item.Name}"));

        public void AddToOut(Driver driver) => _out.Add(driver);

        public Race(string input)
        {
            string[] parts = input.Split('\n');

            string[] raceInfo = parts[0].Split(' ');
            Laps = int.Parse(raceInfo[0]);
            _drivers = new(int.Parse(raceInfo[1]));

            foreach (string line in parts.Skip(1))
            {
                string[] driverInfo = line.Split(' ');

                int type = int.Parse(driverInfo[1]);
                string name = driverInfo[0];

                _drivers.Add(type switch
                {
                    1 => new Aggressive(name, this),
                    2 => new Vibrant(name, this),
                    3 => new Dangerous(name, this),
                    4 => new Careful(name, this),
                    _ => throw new InvalidDriverTypeException(type)
                });
            }
        }

        public void Next()
        {
            CurrentLap++;
            NewOrder = [.. _drivers];
            _drivers.ForEach(x => x.Next());
            _drivers = [.. NewOrder];
        }

        public override string ToString() => $"{CurrentLap} / {Laps}" +
            $"\n\nOrder:\n{string.Join("\n",
                _drivers.Enumerate().Select(x => $"{x.Index + 1}. {x.Item}"))}" +
            $"\n\nOut:\n{string.Join("\n", _out.Select(x => x.Name))}" +
            "\n\n\nPress any key for next lap...";
    }
}
