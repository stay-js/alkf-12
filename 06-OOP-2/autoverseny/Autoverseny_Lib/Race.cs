namespace Autoverseny_Lib
{
    public class Race
    {
        private List<Driver> _drivers;
        private readonly List<Driver> _out = [];
        private List<string> _log = [];

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

        public void AddToOut(Driver driver)
        {
            _out.Add(driver);
            AddToLog($"{driver.Name} is out.");
        }

        public void AddToLog(string message) => _log.Add(message);

        public Race(string input)
        {
            string[] parts = input.Split('\n');

            string[] raceInfo = parts[0].Split(';');
            Laps = int.Parse(raceInfo[0]);
            _drivers = new(int.Parse(raceInfo[1]));

            foreach (string line in parts.Skip(1))
            {
                string[] driverInfo = line.Split(';');
                string name = driverInfo[0];
                int typeNumber = int.Parse(driverInfo[1]);

                DriverType type;

                try
                {
                    type = (DriverType)typeNumber;
                }
                catch
                {
                    throw new InvalidDriverTypeException(typeNumber);
                }


                _drivers.Add(new Driver(name, this, type));
            }
        }

        public void Next()
        {
            _log = [];
            CurrentLap++;
            NewOrder = [.. _drivers];
            _drivers.ForEach(x => x.Next());
            _drivers = [.. NewOrder];
        }

        public override string ToString() => $"{CurrentLap} / {Laps}\n\n" +
            (_log.Count == 0 ? "No events." : string.Join("\n", _log)) +
            $"\n\nOrder:\n{string.Join("\n",
                _drivers.Enumerate().Select(x => $"{x.Index + 1}. {x.Item}"))}" +
            $"\n\nOut:\n{string.Join("\n", _out.Select(x => x.Name))}" +
            "\n\n\nPress any key for next lap...";
    }
}
