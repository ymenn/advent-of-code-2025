long validIdCount = 0;
try
{
    using StreamReader sr = new StreamReader("input.txt");

    string? line;

    List<(long start, long end)> ranges = [];
    while ((line = sr.ReadLine()) is not null)
    {
        if (line?.Equals("") == true)
            break;

        var numStrings = line!.Split('-');
        if (
            !long.TryParse(numStrings[0], out var startNum)
            || !long.TryParse(numStrings[1], out var endNum)
        )
            throw new Exception("Invalid range.");

        ranges.Add((startNum, endNum));
    }

    ranges.Sort((range1, range2) => range1.start.CompareTo(range2.start));

    List<(long start, long end)> mergedRanges = [];

    for (int i = 0; i < ranges.Count; i++)
    {
        if (mergedRanges.Count == 0)
            mergedRanges.Add(ranges[i]);

        if (mergedRanges[mergedRanges.Count - 1].end >= ranges[i].start)
        {
            mergedRanges[mergedRanges.Count - 1] = (
                mergedRanges[mergedRanges.Count - 1].start,
                Math.Max(mergedRanges[mergedRanges.Count - 1].end, ranges[i].end)
            );
            continue;
        }

        mergedRanges.Add(ranges[i]);
    }

    foreach (var range in mergedRanges)
        validIdCount += range.end - range.start + 1;
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.Message}");
}

Console.WriteLine(validIdCount);
