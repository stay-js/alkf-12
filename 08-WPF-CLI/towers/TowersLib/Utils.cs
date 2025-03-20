namespace TowersLib
{
    public static class Utils
    {
        public static bool CheckDuplicates(int[] heights) => heights
            .GroupBy(x => x)
            .Any(g => g.Count() > 1);

        public static int CountVisibleTowers(int[] heights)
        {
            int max = 0;
            int count = 0;

            foreach (int h in heights)
            {
                if (h > max)
                {
                    max = h;
                    count++;
                }
            }

            return count;
        }
    }
}
