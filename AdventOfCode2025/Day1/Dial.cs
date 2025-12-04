namespace AdventOfCode2025;

public class Dial
{
    public int Position { get; private set; }
    public int NumberOfTimesOnZero { get; private set; }

    public Dial()
    {
        Position = 50;
    }

    public void TurnLeft(int distance)
    {
        for (var i = 0; i < distance; i++)
        {
            Position--;
            CheckPosition();
        }
    }
    
    public void TurnRight(int distance)
    {
        for (var i = 0; i < distance; i++)
        {
            Position++;
            CheckPosition();
        }
    }
    
    private void CheckPosition()
    {
        // Console.WriteLine(Position);
        if (Position % 100 == 0)
        {
            IncrementNumberOfTimesOnZero();
        }
    }
    
    private void IncrementNumberOfTimesOnZero()
    {
        Console.WriteLine("+1");
        NumberOfTimesOnZero++;
    }
    
}