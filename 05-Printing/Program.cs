var rules = File.ReadAllLines("input.txt")
    .Where(x => x.Contains('|'));

var updates = File.ReadAllLines("input.txt")
    .Where(x => x.Contains(','))
    .Select(x => x.Split(','));

Console.WriteLine(updates.Where(IsValid).Sum(Mid));

var comparer = Comparer<string>.Create((a, b) =>
    rules.Contains($"{a}|{b}") ? -1 : 1);

var ordered = updates.Where(u => !IsValid(u))
    .Select(u => u.Order(comparer).ToArray());

Console.WriteLine(ordered.Sum(Mid));

bool IsValid(string[] u) => 
    u.Zip(u.Skip(1), (a, b) => $"{a}|{b}")
    .All(rules.Contains);

int Mid(string[] u) => int.Parse(u[u.Length / 2]);