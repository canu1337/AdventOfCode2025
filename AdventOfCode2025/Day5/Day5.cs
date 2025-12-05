namespace AdventOfCode2025.Day5;

public class Day5
{
    public async Task DoStuff()
    {
        var ranges = new List<Range>();
        var products = new List<long>();
        var lines = await File.ReadAllLinesAsync("Day5/input.txt");
        foreach (var line in lines)
        {
            if (line.Contains('-'))
            {
                var parts = line.Split('-');
                ranges.Add(new Range(long.Parse(parts[0]), long.Parse(parts[1])));
            }
            else if (long.TryParse(line, out var product))
            {
                products.Add(product);
            }
        }

        var total = 0;
        foreach (var product in products)
        {
            if (ranges.Any(r => r.IsInRange(product)))
            {
                total++;
            }
        }
        Console.WriteLine(total);
        
    }
    
    public async Task DoStuff2()
    {
        var ranges = new List<Range>();
        var lines = await File.ReadAllLinesAsync("Day5/input.txt");
        foreach (var line in lines)
        {
            if (line.Contains('-'))
            {
                var parts = line.Split('-');
                ranges.Add(new Range(long.Parse(parts[0]), long.Parse(parts[1])));
            }
        }

        long total = 0;
        var rangeCopy = ranges.ToList();
        
        foreach (var range in ranges)
        {
            // vérifier si End est pas contenu dans un range
            var isEndInRangeOf = rangeCopy.FirstOrDefault(r => r.IsInRange(range.End) && r.Id != range.Id);
            if (isEndInRangeOf != null)
            {
                var toRemove = rangeCopy.First(r => r.Id == range.Id);
                rangeCopy.Remove(toRemove);
                var r = rangeCopy.First(r => r.Id == isEndInRangeOf.Id);
                if (range.Start < r.Start)
                {
                    r.Start = range.Start;
                }
            }
            else
            {
                var isStartRangeOf = rangeCopy.FirstOrDefault(r => r.IsInRange(range.Start) && r.Id != range.Id);
                if (isStartRangeOf != null)
                {
                    var toRemove = rangeCopy.First(r => r.Id == range.Id);
                    rangeCopy.Remove(toRemove);
                    var r = rangeCopy.First(r => r.Id == isStartRangeOf.Id);
                    if (range.End > r.End)
                    {
                        r.End = range.End;
                    }
                }    
            }
        }

        foreach (var range in rangeCopy)
        {
            total += range.End - range.Start + 1;
        }
        
        Console.WriteLine(total);
        
    }
}


public record Range(long Start, long End)
{
    public long Start{ get; set;} = Start;
    public long End{ get; set;} = End;
    public Guid Id{ get; set;} = Guid.NewGuid();
    public bool IsInRange(long number) => number >= Start && number <= End;
}