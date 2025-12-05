int dialPosition = 50;
int combination = 0;
try
{
    StreamReader sr = new StreamReader("input.txt");
    // StreamReader sr = new StreamReader("test1.txt");

    string? line = sr.ReadLine();

    while (line is not null)
    {
        if (!int.TryParse(line.Substring(1), out var movements))
        {
            Console.WriteLine(
                $"Failed to parse movement number to int unexpectedly {line.Substring(1)}"
            );
            return 1;
        }

        int fullRotations = movements / 100;
        combination += fullRotations;

        var partialRotation = mod(movements, 100);

        if (line.StartsWith('L'))
        {
            if (dialPosition != 0 && dialPosition - partialRotation <= 0)
                combination++;

            dialPosition = mod(dialPosition - partialRotation, 100);
        }
        else if (line.StartsWith('R'))
        {
            if ((dialPosition + partialRotation) > 99)
                combination++;

            dialPosition = mod(dialPosition + partialRotation, 100);
        }

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

static int mod(int x, int y) => (x % 100 + 100) % 100;
