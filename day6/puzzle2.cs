List<string> lines = [];
try
{
    lines = File.ReadLines("input.txt").ToList();
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

var splitLines = SplitLinesByOperation(lines);

foreach (var splitLine in splitLines)
{
    for (int i = 0; i < splitLine.Count(); i++)
    {
        if (i >= operationNumberStrings.Count)
        {
            operationNumberStrings.Add([]);
        }

        var numChars = splitLine[i].ToArray();

        for (int j = 0; j < numChars.Count(); j++)
        {
            if (j >= operationNumberStrings[i].Count)
            {
                operationNumberStrings[i].Add("");
            }

            if (!numChars[j].Equals(' '))
                operationNumberStrings[i][j] += numChars[j];
        }
    }
}

for (int i = 0; i < operations.Count(); i++)
{
    var operation = operations[i];
    long operationResult;
    if (operation.Equals("*"))
    {
        operationResult = 1L;
        foreach (var numberString in operationNumberStrings[i])
        {
            if (!long.TryParse(numberString, out var number))
                throw new Exception("Invalid number string");
            operationResult *= number;
        }
    }
    else
    {
        operationResult = 0L;
        foreach (var numberString in operationNumberStrings[i])
        {
            if (!long.TryParse(numberString, out var number))
                throw new Exception("Invalid number string");
            operationResult += number;
        }
    }

    sum += operationResult;
}

Console.WriteLine(sum);

static List<List<string>> SplitLinesByOperation(List<string> lines)
{
    List<List<string>> result = [];
    for (int x = 0; x < lines.Count(); x++)
        result.Add([]);

    int currentStartInd = 0;
    for (int i = 0; i < lines[0].Count(); i++)
    {
        var allEmpty = true;
        foreach (var line in lines)
        {
            if (!line[i].Equals(' '))
            {
                allEmpty = false;
                break;
            }
        }
        if (!allEmpty)
            continue;

        for (int z = 0; z < lines.Count(); z++)
        {
            result[z].Add(lines[z].Substring(currentStartInd, i - currentStartInd));
        }
        currentStartInd = i + 1;
    }
    for (int z = 0; z < lines.Count(); z++)
    {
        result[z].Add(lines[z].Substring(currentStartInd, lines[z].Count() - currentStartInd));
    }

    return result;
}
