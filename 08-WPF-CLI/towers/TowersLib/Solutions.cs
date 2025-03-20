namespace TowersLib
{
    public class Solutions
    {
        private readonly List<Solution> _solutions = [];

        public Solutions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int start = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                if (char.IsLetter(lines[i][0]) || i == lines.Length - 1)
                {
                    _solutions.Add(new Solution(lines[start],
                        lines.Skip(start + 1).Take(i - start - 1).ToArray()));
                    start = i;
                }
            }
        }

        public int Count => _solutions.Count;

        public IEnumerable<string> GaveCorrectSolution => _solutions
            .Where(x => x.IsValid)
            .Select(x => x.Name);

        public Solution? GetSolution(string name) => _solutions.Find(x => x.Name == name);
    }
}
