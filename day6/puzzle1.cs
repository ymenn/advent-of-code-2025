long sum = 0;
try
{
    var sr = new StreamReader("input.txt");
    List<string> lines = [];
    string? line;

    while ((line = sr.ReadLine()) is not null)
    {
        lines.Add(line);
    }

    var operations = lines[lines.Count - 1]
        .Trim()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    List<long> solution = operations.Select(operation => operation == "*" ? 1L : 0L).ToList();

    for (int i = 0; i < lines.Count - 1; i++)
    {
        var splitLine = lines[i].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int j = 0; j < splitLine.Count(); j++)
        {
            var numberString = splitLine[j];

            if (!long.TryParse(numberString, out var number))
                throw new Exception("Invalid number");

            if (operations[j].Equals("+"))
            {
                solution[j] += number;
            }
            else
            {
                solution[j] *= number;
            }
        }
    }

    sum = solution.Sum();
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
}

Console.WriteLine(sum);
