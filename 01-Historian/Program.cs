var lines = File.ReadAllLines("input.txt");
var left = lines.Select(x => int.Parse(x[..5])).Order();
var right = lines.Select(x => int.Parse(x[^5..])).Order();
Console.WriteLine(left.Zip(right, (a, b) => Math.Abs(a - b)).Sum());
Console.WriteLine(left.Sum(x => right.Count(r => r == x) * x));