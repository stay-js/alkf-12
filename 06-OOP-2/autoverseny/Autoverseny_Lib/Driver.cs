namespace Autoverseny_Lib
{
    public partial class Driver
    {
        protected const int FUEL_CONSUMPTION_PER_LAP = 5;
        protected const int REFUEL_PLACE_PENALTY = 5;

        protected int MIN_FUEL_LEVEL;

        public string Name { get; init; }
        public int FuelLevel { get; private set; } = 100;
        public DriverType Type { get; init; }

        private readonly Race _race;

        public Driver(string name, Race race, DriverType type)
        {
            _race = race;
            Name = name;
            Type = type;

            switch (Type)
            {
                case DriverType.Aggressive:
                    MIN_FUEL_LEVEL = 10;
                    OVERTAKE_LAPS = 2;
                    OVERTAKE_SUCCESS = 3;
                    break;
                case DriverType.Careful:
                    MIN_FUEL_LEVEL = 20;
                    OVERTAKE_LAPS = int.MaxValue;
                    OVERTAKE_SUCCESS = 1;
                    break;
                case DriverType.Dangerous:
                    MIN_FUEL_LEVEL = 5;
                    OVERTAKE_LAPS = 4;
                    OVERTAKE_SUCCESS = 4;

                    DANGER_MULTIPLIER = 2;
                    break;
                case DriverType.Vibrant:
                    MIN_FUEL_LEVEL = 20;
                    OVERTAKE_LAPS = 5;
                    OVERTAKE_SUCCESS = 2;
                    break;
            }
        }

        public void Next()
        {
            FuelLevel -= FUEL_CONSUMPTION_PER_LAP;
            if (FuelLevel < MIN_FUEL_LEVEL) Refuel();
            else TryOvertake();
        }

        private void Refuel()
        {
            FuelLevel = 100;

            int index = _race.NewOrder.IndexOf(this);
            _race.NewOrder.Remove(this);


            if (index + REFUEL_PLACE_PENALTY >= _race.DriverCount - 1)
                _race.NewOrder.Add(this);
            else
                _race.NewOrder.Insert(index + REFUEL_PLACE_PENALTY, this);

            _race.AddToLog($"{Name} has refueld.");
        }

        public override string ToString() => $"{Name} (Fuel level: {FuelLevel}%) - {Type}";
    }
}
