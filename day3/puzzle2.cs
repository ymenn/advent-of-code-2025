long runningTotal = 0;
try
{
    var sr = new StreamReader("input.txt");

    var line = sr.ReadLine();
    while (line is not null)
    {
        long joltage = 0;
        int start = 0;

        for (int j = 0; j < 12; j++)
        {
            (int num, int pos) largest = (0, 0);
            for (int i = start; i < line.Length - (11 - j); i++)
            {
                if (!int.TryParse(line.Substring(i, 1), out var potentialDigit))
                    continue;

                if (potentialDigit > largest.num)
                {
                    largest = (potentialDigit, i);
                }
            }
            start = largest.pos + 1;
            joltage += ((long)Math.Pow(10, 11 - j)) * largest.num;
        }
        runningTotal += joltage;
        line = sr.ReadLine();
    }
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
    return 1;
}

// POSSIBLE RANGE 100000000000*200 <-> 999999999999*200
long minimum = 20000000000000,
    maximum = 199999999999800;

if (runningTotal < minimum || runningTotal > maximum)
    Console.WriteLine("Value is outside the expected range");

Console.WriteLine($"Total Joltage --> {runningTotal}");

return 0;
