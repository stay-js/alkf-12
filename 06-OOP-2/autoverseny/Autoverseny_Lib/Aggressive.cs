namespace Autoverseny_Lib
{
    public class Aggressive : Driver
    {
        public Aggressive(string name, Race race) : base(name, race)
        {
            MIN_FUEL_LEVEL = 10;
            OVERTAKE_LAPS = 2;
            OVERTAKE_SUCCESS = 3;
        }
    }
}
