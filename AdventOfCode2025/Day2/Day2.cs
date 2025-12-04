namespace AdventOfCode2025.Day2;

public class Day2
{
    public void DoStuff()
    {
        Console.WriteLine("Hello, World!");
        double res = 0;
        var ranges = new List<DoubleRange>();
        var line = File.ReadAllText("Day2/input.txt");
        var segments = line.Split(',');
        foreach (var range in segments)
        {
            var bounds = range.Split('-');
            ranges.Add(new DoubleRange(double.Parse(bounds[0]), double.Parse(bounds[1])));
        }

        foreach (var range in ranges)
        {
            for (double i = range.Start; i <= range.End; i++)
            {
                var isValid = IsValid2(i);
                if (!isValid)
                {
                    res += i;
                }
            }
        }
        Console.WriteLine(res);
    }
    public static bool IsValid(double number)
    {
        var str = number.ToString();
        var nbIteration = str.Length / 2;
        for (var i = 1; i <= nbIteration; i++)
        {
            var firstHalf = str[..i];
            var secondHalf = str[i..];
            if (firstHalf == secondHalf)
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsValid2(double number)
    {
        var str = number.ToString();
        for (var i = 1; i < str.Length; i++)
        {
            for (var j = 1; i + j <= str.Length; j++)
            {
                var substr = str.Substring(i, j);
                var r = str.Split(substr);
                if (r.All(x => x.Length == 0))
                {
                    Console.WriteLine($"{number} is invalid because {substr}");
                    return false;
                }
            }
        }


        return true;
    }
}

public record DoubleRange(double Start, double End);

