long runningTotal = 0;
try
{
    var sr = new StreamReader("input.txt");

    var line = sr.ReadLine();
    while (line is not null)
    {
        (int number, int pos) leftNumber = (0, -1);

        for (int i = 0; i < line.Length - 1; i++)
        {
            if (int.TryParse(line.Substring(i, 1), out var number))
            {
                if (leftNumber.number < number)
                    leftNumber = (number, i);
            }
        }

        int rightNumber = 0;

        for (int j = leftNumber.pos + 1; j < line.Length; j++)
        {
            if (int.TryParse(line.Substring(j, 1), out var possibleNumber))
            {
                if (possibleNumber > rightNumber)
                    rightNumber = possibleNumber;
            }
        }

        runningTotal += (leftNumber.number * 10) + rightNumber;

        line = sr.ReadLine();
    }
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
    return 1;
}

Console.WriteLine(runningTotal);

return 0;
