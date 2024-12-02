
var lines = File.ReadAllLines("input.txt");
var left = lines.Select(x => int.Parse(x[..5])).Order().ToArray();
var right = lines.Select(x => int.Parse(x[^5..])).Order().ToArray();

int sum = 0;
for (int i = 0; i < left.Length; i++)
    sum += Math.Abs(left[i] - right[i]);

Console.WriteLine(sum);

int score = 0;
foreach (var n in left)
    score += right.Count(x => x == n) * n;

Console.WriteLine(score);