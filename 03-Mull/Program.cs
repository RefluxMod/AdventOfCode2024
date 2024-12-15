using System.Text.RegularExpressions;

var s = File.ReadAllText("input.txt");
var match = Regex.Matches(s, @"mul\((\d{1,3}),(\d{1,3})\)");

Console.WriteLine(match.Sum(Mul));
Console.WriteLine(match.Where(Enabled).Sum(Mul));

int Mul(Match m) => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value);
bool Enabled(Match m) => s.LastIndexOf("do()", m.Index) >= s.LastIndexOf("don't()", m.Index);