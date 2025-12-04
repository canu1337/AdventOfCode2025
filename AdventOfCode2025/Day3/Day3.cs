namespace AdventOfCode2025;

public class Day3
{
    public async Task DoStuff()
    {
        var sum = 0;
        var line = await File.ReadAllLinesAsync("Day3/input.txt");
        foreach (var l in line)
        {
            var max = 0;
            for (var i = 0; i < l.Length - 1; i++)
            {
                var current = l[i];
                for (var j = i + 1; j < l.Length; j++)
                {
                    var b = int.Parse($"{current}{l[j]}");
                    if (b > max)
                    {
                        max = b;
                    }
                }
            }
            Console.WriteLine(max);
            sum += max;
        }
        Console.WriteLine(sum);
    }
    
    public async Task DoStuff2()
    {
        Console.WriteLine("Hello, World!");
        double sum = 0;
        var lines = await File.ReadAllLinesAsync("Day3/input.txt");
        foreach (var l in lines)
        {
            var line = l;
            string res = "";
            for(int i = 11; i >= 0; i--)
            {
                // virer les i - 1 derniers chars
                var window = line.Substring(0, line.Length - i);
                var max = window.Max();
                res += max;
                line = line.Substring(line.IndexOf(max, StringComparison.Ordinal) + 1);
            }
            Console.WriteLine(res);
            sum += double.Parse(res);
        }
        Console.WriteLine(sum);
    }
}