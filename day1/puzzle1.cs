int runningSum = 50;
int combination = 0;
try
{
    StreamReader sr = new StreamReader("input.txt");

    string? line = sr.ReadLine();

    while (line is not null)
    {
        // Console.WriteLine(line.Substring(1).GetType());
        if (!int.TryParse(line.Substring(1), out var movements))
        {
            Console.WriteLine(
                $"Failed to parse movement number to int unexpectedly {line.Substring(1)}"
            );
            return 1;
        }

        if (line.StartsWith('L'))
        {
            runningSum = (runningSum - movements) % 100;
        }
        else
        {
            runningSum = (runningSum + movements) % 100;
        }

        if (runningSum == 0)
            combination++;
        line = sr.ReadLine();
    }

    Console.WriteLine(combination);
    return 0;
}
catch (Exception e)
{
    Console.Write($"Error: {e}");
    return 1;
}
