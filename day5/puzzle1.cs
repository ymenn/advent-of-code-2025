int validIdCount = 0;
try
{
    using StreamReader sr = new StreamReader("input.txt");

    string? line;

    List<(long start, long end)> ranges = [];
    while ((line = sr.ReadLine()) is not null)
    {
        if (line?.Equals("") == true)
            break;

        var numStrings = line.Split('-');

        if (
            !long.TryParse(numStrings[0], out var startNum)
            || !long.TryParse(numStrings[1], out var endNum)
        )
            throw new Exception("Invalid range.");

        ranges.Add((startNum, endNum));
    }

    while ((line = sr.ReadLine()) is not null)
    {
        Console.WriteLine(line);

        if (!long.TryParse(line, out var productId))
            throw new Exception("Invalid productId.");

        foreach ((long startNum, long endNum) in ranges)
        {
            if (productId >= startNum && productId <= endNum)
            {
                validIdCount++;
                break;
            }
        }
    }
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.Message}");
}

Console.WriteLine(validIdCount);
