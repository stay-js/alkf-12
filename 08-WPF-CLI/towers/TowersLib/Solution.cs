namespace TowersLib
{
    public class Solution
    {
        private readonly int[,] _heights;

        public string Name { get; }

        public int Size => _heights.GetLength(0);

        public bool IsValid =>
            _heights.Cast<int>().All(x => x > 0 && x <= Size) &&
            Enumerable
            .Range(0, Size)
            .All(i => !Utils.CheckDuplicates(GetNumbersInRow(i))
            && !Utils.CheckDuplicates(GetNumbersInColumn(i)));

        public Solution(string name, string[] input)
        {
            Name = name;
            _heights = new int[input.Length, input.Length];

            for (int i = 0; i < Size; i++)
            {
                int[] heights = input[i].Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < Size; j++)
                {
                    _heights[i, j] = heights[j];
                }
            }
        }

        public int[] Top() => Enumerable
            .Range(0, Size)
            .Select(i => Utils.CountVisibleTowers(GetNumbersInColumn(i)))
            .ToArray();

        public int[] Bottom() => Enumerable
            .Range(0, Size)
            .Select(i => Utils.CountVisibleTowers(GetNumbersInColumn(i).Reverse().ToArray()))
            .ToArray();

        public int[] Left() => Enumerable
            .Range(0, Size)
            .Select(i => Utils.CountVisibleTowers(GetNumbersInRow(i)))
            .ToArray();

        public int[] Right() => Enumerable
            .Range(0, Size)
            .Select(i => Utils.CountVisibleTowers(GetNumbersInRow(i).Reverse().ToArray()))
            .ToArray();

        public int[] GetNumbersInRow(int row)
        {
            int[] numbers = new int[Size];

            for (int i = 0; i < Size; i++)
            {
                numbers[i] = _heights[row, i];
            }

            return numbers;
        }

        private int[] GetNumbersInColumn(int col)
        {
            int[] numbers = new int[Size];

            for (int i = 0; i < Size; i++)
            {
                numbers[i] = _heights[i, col];
            }

            return numbers;
        }
    }
}
