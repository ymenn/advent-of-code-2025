using System.Numerics;

Dictionary<long, long> timelines = [];
try
{
    var sr = new StreamReader("test.txt");

    string? line;
    int x = 0;
    while ((line = sr.ReadLine()) is not null)
    {
        Console.Write($"[{x:00}] ");
        var tempTimelines = new Dictionary<long, long>(timelines);
        for (int i = 0; i < line.Count(); i++)
        {
            var character = line[i];
            long aboveBeamCount = 0L;
            if (character.Equals('S'))
            {
                tempTimelines[i] = 1;
                Console.Write('S');
            }
            else if (
                character.Equals('^')
                && (aboveBeamCount = timelines.GetValueOrDefault(i, 0)) > 0
            )
            {
                Console.Write('^');
                if (!timelines.ContainsKey(i + 1))
                    tempTimelines[i + 1] = 0;

                tempTimelines[i + 1] += aboveBeamCount;

                if (!timelines.ContainsKey(i - 1))
                    tempTimelines[i - 1] = 0;

                tempTimelines[i - 1] += aboveBeamCount;

                tempTimelines[i] = 0;
            }
            else
            {
                if (character.Equals('.') && timelines.GetValueOrDefault(i, 0) > 0)
                {
                    Console.Write(timelines.GetValueOrDefault(i, 0));
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.Write('|');
        }
        timelines = new(tempTimelines);
        Console.WriteLine("");
        x++;
    }

    Console.WriteLine(timelines);
    Console.WriteLine(timelines.Values.ToList().Sum());
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
}
