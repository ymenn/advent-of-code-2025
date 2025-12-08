List<string> lines = [];
try
{
    lines = File.ReadLines("test.txt").ToList();
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
}

long sum = 0;

List<string> operations = lines[lines.Count - 1]
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
lines.RemoveAt(lines.Count - 1);

List<List<string>> operationNumberStrings = [];

foreach (var line in lines)
{
    string[] splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries); // Need to split only on spaces between numbers not those padding the string
    for (int i = 0; i < splitLine.Count(); i++)
    {
        if (i >= operationNumberStrings.Count)
            operationNumberStrings.Add([]);

        var numChars = splitLine[i].ToArray();

        for (int j = 0; j < numChars.Count(); j++)
        {
            if (operationNumberStrings[i].Count >= j)
                operationNumberStrings[i].Add("");

            operationNumberStrings[i][j] += numChars[j];
        }
    }
}

foreach (var operation in operationNumberStrings)
{
    foreach (var stringNum in operation)
    {
        Console.Write(stringNum + ",");
    }
    Console.WriteLine();
}
Console.WriteLine(sum);

static List<string> SplitStringKeepPadding(string line) { }
