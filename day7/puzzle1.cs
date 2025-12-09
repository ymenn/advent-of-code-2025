using System.Collections.Generic;

int splits = 0;
try
{
    var sr = new StreamReader("input.txt");

    string? line;
    HashSet<int> beams = [];
    while ((line = sr.ReadLine()) is not null)
    {
        HashSet<int> tempBeams = new HashSet<int>(beams);
        Console.WriteLine($"NEW LINE ___");
        for (int i = 0; i < line.Count(); i++)
        {
            var character = line[i];
            if (character.Equals('S'))
            {
                tempBeams.Add(i);
            }
            else if (character.Equals('^') && beams.Contains(i))
            {
                splits++;
                if (i < line.Count() - 1)
                    tempBeams.Add(i + 1);

                if (i > 1)
                    tempBeams.Add(i - 1);

                tempBeams.Remove(i);
            }
        }
        foreach (var val in tempBeams)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine("");

        beams = new HashSet<int>(tempBeams);
    }

    Console.WriteLine(splits);
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
}
