var grid = File.ReadAllLines("input.txt");

(int dx, int dy)[] directions = 
{
    (1,0),(-1,0),(0,1),(0,-1),
    (1,1),(-1,-1),(1,-1),(-1,1)
};

var map = (from y in Enumerable.Range(0, grid.Length)
           from x in Enumerable.Range(0, grid[0].Length)
           select new KeyValuePair<(int X, int Y), char>((x, y), grid[y][x]))
           .ToDictionary();

var part1 = from pos in map.Keys
            from d in directions
            where Match(pos.X, pos.Y, d.dx, d.dy, "XMAS")
            select 1;

Console.WriteLine(part1.Sum());
    
var part2 = from pos in map.Keys 
            where MatchX(pos.X - 1, pos.Y + 1, 1, -1) &&
                  MatchX(pos.X - 1, pos.Y - 1, 1, 1)
            select 1;

Console.WriteLine(part2.Sum());

bool Match(int x, int y, int dx, int dy, string w) =>
    w.Select((_, i) => map.GetValueOrDefault((x + i * dx, y + i * dy)))
    .SequenceEqual(w);

bool MatchX(int x, int y, int dx, int dy) =>
    Match(x, y, dx, dy, "MAS") || Match(x, y, dx, dy, "SAM");