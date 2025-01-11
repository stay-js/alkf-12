namespace Autoverseny_Lib
{
    public class Vibrant : Driver
    {
        public Vibrant(string name, Race race) : base(name, race)
        {
            MIN_FUEL_LEVEL = 20;
            OVERTAKE_LAPS = 5;
            OVERTAKE_SUCCESS = 2;
        }
    }
}
