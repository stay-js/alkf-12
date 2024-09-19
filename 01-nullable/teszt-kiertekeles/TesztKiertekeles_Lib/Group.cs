﻿namespace TesztKiertekeles_Lib
{
    public class Group(IEnumerable<string> lines)
    {
        private readonly List<Result>? _results = lines.Count() == 1
            ? null
            : lines.Skip(1).Select(line => new Result(line)).ToList();

        public bool HasWrittenTest => _results is not null;

        public int Absent => _results?.Count(x => x.Name is null) ?? 0;

        public int TookTheTest => _results?.Count(x => x.Name is not null) ?? 0;

        public Result? GetResultByName(string name)
        {
            try
            {
                return _results?.First(x => x.Name == name);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public int SubmittedEmpty => _results?.Count(x => x.SubmittedEmpty) ?? 0;

        public IEnumerable<string>? Results => _results?
            .Enumerate()
            .Select(x => x.Item.Name is null
                ? $"{x.Index + 1};;;"
                : $"{x.Index + 1};" +
                    $"{x.Item.Name};" +
                    $"{x.Item.Percentage:P0};" +
                    $"{(x.Item.Passed ? "sikeres" : "sikertelen")}");
    }
}