var grid = File.ReadAllLines("input.txt");

var height = grid.Length;
var width = grid[0].Length;

var antennas =
    from y in Enumerable.Range(0, height)
    from x in Enumerable.Range(0, width)
    where grid[y][x] != '.'
    select (X: x, Y: y, V: grid[y][x]);

Console.WriteLine(GetPositions(false).Count);
Console.WriteLine(GetPositions(true).Count);


HashSet<(int, int)> GetPositions(bool harmonics) =>
    (from a1 in antennas
     from a2 in antennas
     where a1 != a2 && a1.V == a2.V
     from n in GetAntinodes(a1.X, a1.Y, a2.X, a2.Y, harmonics)
     select n).ToHashSet();

IEnumerable<(int X, int Y)> GetAntinodes(int x1, int y1, int x2, int y2, bool harmonics)
{
    int dirX = x2 - x1;
    int dirY = y2 - y1;
    int nX = harmonics ? x2 : x2 + dirX;
    int nY = harmonics ? y2 : y2 + dirY;

    while (nX >= 0 && nX < width && nY >= 0 && nY < height)
    {
        yield return (nX, nY);
        if (!harmonics) break;
        nX += dirX;
        nY += dirY;
    }
}