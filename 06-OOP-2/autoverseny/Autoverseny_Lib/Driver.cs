namespace Autoverseny_Lib
{
    public abstract partial class Driver(string name, Race race)
    {
        protected const int FUEL_CONSUMPTION_PER_LAP = 5;
        protected const int REFUEL_PLACE_PENALTY = 5;

        protected int MIN_FUEL_LEVEL;

        private readonly Race _race = race;

        public string Name { get; } = name;

        public int FuelLevel { get; private set; } = 100;

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
        }

        public override string ToString() => $"{Name} (Fuel level: {FuelLevel}%) - {GetType().Name}";
    }
}
