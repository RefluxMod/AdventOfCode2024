var reports = from l in File.ReadAllLines("input.txt")
              select l.Split().Select(int.Parse);

Console.WriteLine(reports.Count(IsSafe));

var safe = from r in reports
           from i in Enumerable.Range(0, r.Count())
           where IsSafe(r.Where((_, n) => n != i))
           select r;

Console.WriteLine(safe.Distinct().Count());

bool IsSafe(IEnumerable<int> r) =>
    r.Zip(r.Skip(1), (a, b) => b - a) is var diffs
    && diffs.All(d => d is > 0 and < 4)
    || diffs.All(d => d is < 0 and > -4);