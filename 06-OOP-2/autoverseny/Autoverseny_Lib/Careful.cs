namespace Autoverseny_Lib
{
    public class Careful : Driver
    {
        public Careful(string name, Race race) : base(name, race)
        {
            MIN_FUEL_LEVEL = 20;
            OVERTAKE_LAPS = int.MaxValue;
            OVERTAKE_SUCCESS = 1;
        }
    }
}
