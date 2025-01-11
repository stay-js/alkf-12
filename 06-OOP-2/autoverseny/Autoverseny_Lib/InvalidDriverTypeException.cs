namespace Autoverseny_Lib
{
    public class InvalidDriverTypeException(int type)
        : Exception($"Invalid driver type: {type}")
    { }
}
