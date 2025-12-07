List<List<char>> grid = [];
try
{
    grid = File.ReadLines("input.txt").Select(line => line.ToList()).ToList();
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.Message}");
    return 1;
}

int accessableRolls = 0;

static (int rollsPickedUp, List<List<char>> newGrid) ProcessGrid(List<List<char>> grid)
{
    int accessableRolls = 0;
    List<List<char>> newGrid = [];
    for (int y = 0; y < grid.Count; y++)
    {
        newGrid.Add([]);
        for (int x = 0; x < grid[0].Count; x++)
        {
            if (!grid[y][x].Equals('@'))
            {
                newGrid[y].Add(grid[y][x]);
                continue;
            }

            int rollCount = 0;
            for (int i = y - 1; i < y + 2; i++)
            {
                for (int j = x - 1; j < x + 2; j++)
                {
                    if (
                        i < 0
                        || i > grid.Count - 1
                        || j < 0
                        || j > grid[0].Count - 1
                        || (i == y && j == x)
                    )
                        continue;

                    if (grid[i][j].Equals('@'))
                        rollCount++;
                }
            }
            if (rollCount < 4)
            {
                accessableRolls++;
                newGrid[y].Add('.');
            }
            else
            {
                newGrid[y].Add('@');
            }
        }
    }
    return (accessableRolls, newGrid);
}

// Could also have done this recursively prob
(int toAdd, List<List<char>> newGrid) result = ProcessGrid(grid);

while (result.toAdd != 0)
{
    accessableRolls += result.toAdd;
    result = ProcessGrid(result.newGrid);
}
Console.WriteLine(accessableRolls);

return 0;
