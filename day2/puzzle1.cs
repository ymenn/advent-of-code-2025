static List<(long start, long end)>? ParseRanges(string filepath)
{
    List<(long start, long end)> ranges = [];
    try
    {
        StreamReader sr = new StreamReader("input.txt");

        string[] rangeStrings = sr.ReadToEnd().Split(',');

        foreach (var rangeString in rangeStrings)
        {
            string[] numberStrings = rangeString.Split('-');
            if (numberStrings.Length != 2)
                throw new Exception("Unexpected more or less than 2 numbers in range string.");

            long.TryParse(numberStrings[0], out var number1);
            long.TryParse(numberStrings[1], out var number2);

            ranges.Add((number1, number2));
        }
    }
    catch
    {
        Console.WriteLine($"Failed to parse {filepath}");
        return null;
    }

    return ranges;
}

var ranges = ParseRanges("input.txt");

if (ranges is null)
{
    Console.WriteLine("Failed to parse input file.");
    return 1;
}

long invalidIdSum = 0;

foreach (var rangeBounds in ranges)
{
    for (long i = rangeBounds.start; i <= rangeBounds.end; i++)
    {
        // Check if its number has an even number of digits, if not return early, no need to check
        if ((Math.Floor(Math.Log10(i)) + 1) % 2 != 0)
            continue;

        string stringNumber = i.ToString();

        int middleIndex = stringNumber.Length / 2;

        string firstHalf = stringNumber.Substring(0, middleIndex);
        string secondHalf = stringNumber.Substring(middleIndex, (int)stringNumber.Length / 2);

        if (firstHalf.Equals(secondHalf))
        {
            // Console.WriteLine($"{stringNumber} -> {firstHalf} | {secondHalf}");
            invalidIdSum += i;
        }
    }
}

Console.WriteLine(invalidIdSum);
return 0;
