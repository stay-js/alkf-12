namespace Autoverseny_Lib
{
    public class Dangerous : Driver
    {
        public Dangerous(string name, Race race) : base(name, race)
        {
            MIN_FUEL_LEVEL = 5;
            OVERTAKE_LAPS = 4;
            OVERTAKE_SUCCESS = 4;

            DANGER_MULTIPLIER = 2;
        }
    }
}
