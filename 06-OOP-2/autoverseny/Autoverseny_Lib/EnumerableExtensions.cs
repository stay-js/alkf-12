namespace Autoverseny_Lib
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(int Index, T Item)> Enumerate<T>(this IEnumerable<T> source)
        {
            int index = 0;

            foreach (var item in source)
            {
                yield return (index++, item);
            }
        }
    }
}
