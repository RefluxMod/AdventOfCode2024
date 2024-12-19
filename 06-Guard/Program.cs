var map = File.ReadAllLines("input.txt").Select(x => x.ToArray()).ToArray();

var width = map[0].Length;
var height = map.Length;
var directions = new[] { (0, -1), (1, 0), (0, 1), (-1, 0) }; // up, right, down, left

var (x1, y1) = (from y in Enumerable.Range(0, height)
                from x in Enumerable.Range(0, width)
                where map[y][x] == '^'
                select (x, y)).First();

var visited = Walk(x1, y1).Visited;

Console.WriteLine(visited.Count());

int loops = 0;
foreach (var (x, y) in visited.Where(v => map[v.Y][v.X] == '.'))
{
    map[y][x] = '#';
    if (Walk(x1, y1).Loop)
        loops++;
    map[y][x] = '.';
}

Console.WriteLine(loops);


((int X, int Y)[] Visited, bool Loop) Walk(int x, int y)
{
    var visited = new HashSet<(int X, int Y, int D)>();
    var dirIndex = 0;

    while (visited.Add((x, y, dirIndex)))
    {
        var (dx, dy) = directions[dirIndex];
        var (nx, ny) = (x + dx, y + dy);

        if (nx < 0 || ny < 0 || nx >= width || ny >= height)
            return ([.. visited.Select(v => (v.X, v.Y)).Distinct()], false);

        if (map[ny][nx] == '#')
            dirIndex = ++dirIndex % 4;
        else
            (x, y) = (nx, ny);
    }

    return ([], true);
}