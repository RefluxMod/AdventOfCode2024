using System.Text.RegularExpressions;
using Op = System.Func<long, long, long>;

var rows = from l in File.ReadAllLines("input.txt")
           let m = Regex.Matches(l, @"\d+").Select(x => long.Parse(x.Value))
           select (Target: m.First(), Nums: m.Skip(1).ToArray());

Op[] ops = { (x, y) => x + y, (x, y) => x * y, (x, y) => long.Parse($"{x}{y}") };

Console.WriteLine(Sum(ops[..2]));
Console.WriteLine(Sum(ops));

long Sum(Op[] ops) =>
    rows.Sum(x => Results(ops, x.Nums).Contains(x.Target) ? x.Target : 0);

IEnumerable<long> Results(Op[] ops, long[] nums, long acc = 0) =>
    nums is [] ? [acc] : ops.SelectMany(f => Results(ops, nums[1..], f(acc, nums[0])));