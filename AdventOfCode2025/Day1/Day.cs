namespace AdventOfCode2025;

public class Day
{
    public void DoStuff()
    {
        Console.WriteLine("Hello, World!");

        var lines = File.ReadAllLines("input.txt");
        var dial = new Dial();
        foreach (var line in lines)
        {
            if (line.Length > 0)
            {
                var direction = line[0];
                var distance = int.Parse(line[1..]);
                if (direction == 'R')
                {
                    dial.TurnRight(distance);
                }
                else if (direction == 'L')
                {
                    dial.TurnLeft(distance);
                }
            }
        }

        Console.WriteLine(dial.NumberOfTimesOnZero);
    }
}