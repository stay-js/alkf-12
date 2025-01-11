namespace Autoverseny_Lib
{
    public partial class Driver
    {
        protected const int OVERTAKE_FUEL_CONSUMPTION = 4;

        protected const int ATTACKER_OUT_CHANCE = 4;
        protected const int BOTH_OUT_CHANCE = 4;
        protected const int MASS_CRASH_CHANCE = 2;

        protected int OVERTAKE_LAPS;
        protected int OVERTAKE_SUCCESS;
        protected int DANGER_MULTIPLIER = 1;

        private int overtakeTrialCount = 0;

        private void TryOvertake()
        {
            int index = _race.NewOrder.IndexOf(this);
            if (index == 0) return;

            if (_race.CurrentLap % OVERTAKE_LAPS != 0) return;
            if (FuelLevel < OVERTAKE_FUEL_CONSUMPTION) return;

            overtakeTrialCount++;

            int defenderIndex = index - 1;
            var defender = _race.NewOrder[defenderIndex];

            if (Random.Shared.Next(100) < MASS_CRASH_CHANCE * DANGER_MULTIPLIER)
            {
                if (index + 1 < _race.DriverCount - 1)
                {
                    var driver = _race.NewOrder[index + 1];
                    _race.AddToOut(driver);
                    _race.NewOrder.Remove(driver);
                }

                _race.AddToOut(this);
                _race.NewOrder.Remove(this);

                _race.AddToOut(defender);
                _race.NewOrder.Remove(defender);

                if (defenderIndex > 0)
                {
                    var driver = _race.NewOrder[defenderIndex - 1];
                    _race.AddToOut(driver);
                    _race.NewOrder.Remove(driver);
                }

                return;
            }

            if (Random.Shared.Next(100) < BOTH_OUT_CHANCE * DANGER_MULTIPLIER)
            {
                _race.AddToOut(this);
                _race.NewOrder.Remove(this);

                _race.AddToOut(defender);
                _race.NewOrder.Remove(defender);

                return;
            }

            if (Random.Shared.Next(100) < ATTACKER_OUT_CHANCE * DANGER_MULTIPLIER)
            {
                _race.AddToOut(this);
                _race.NewOrder.Remove(this);

                return;
            }

            if (overtakeTrialCount % OVERTAKE_SUCCESS == 0)
            {
                (_race.NewOrder[defenderIndex], _race.NewOrder[index]) =
                    (_race.NewOrder[index], _race.NewOrder[defenderIndex]);
            }
        }
    }
}
