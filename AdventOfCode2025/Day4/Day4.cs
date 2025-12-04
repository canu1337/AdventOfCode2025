namespace AdventOfCode2025.Day4;

public class Day4
{
    public async Task DoStuff()
    {
        var lines = await File.ReadAllLinesAsync("Day4/input.txt");
        var width = lines[0].Length;
        var height = lines.Length;
        
        var grid = new char[width,height];
        for (int i = 0; i < width; i++)
        {
            var line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                grid[i,j] = line[j];
            }
        }

        var accessible = 0;
        for (var i = 0; i < width; i++)
        {
            for(var j = 0; j < height; j++)
            {
                var c = grid[i,j];
                if (c == '@')
                {
                    var total =
                    IsLeftRoll(grid, i, j) +
                    IsRightRoll(grid, i, j) +
                    IsUpRoll(grid, i, j) +
                    IsDownRoll(grid, i, j) +
                    IsUpLeftRoll(grid, i, j) +
                    IsUpRightRoll(grid, i, j) +
                    IsDownLeftRoll(grid, i, j) +
                    IsDownRightRoll(grid, i, j);
                    if (total < 4)
                    {
                        accessible++;
                        Console.WriteLine($"{i},{j} is accessible");
                    }
                }
            }
        }
        Console.WriteLine(accessible);
    }

    
    public async Task DoStuff2()
    {
        var lines = await File.ReadAllLinesAsync("Day4/input.txt");
        var width = lines[0].Length;
        var height = lines.Length;
        
        var grid = new char[width,height];
        for (int i = 0; i < width; i++)
        {
            var line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                grid[i,j] = line[j];
            }
        }
        
        var totalAccessible = 0;
        var accessible = 1;
        while (accessible != 0)
        {
            accessible = 0;
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var c = grid[i, j];
                    if (c == '@')
                    {
                        var total =
                            IsLeftRoll(grid, i, j) +
                            IsRightRoll(grid, i, j) +
                            IsUpRoll(grid, i, j) +
                            IsDownRoll(grid, i, j) +
                            IsUpLeftRoll(grid, i, j) +
                            IsUpRightRoll(grid, i, j) +
                            IsDownLeftRoll(grid, i, j) +
                            IsDownRightRoll(grid, i, j);
                        if (total < 4)
                        {
                            accessible++;
                            // Console.WriteLine($"{i},{j} is accessible");
                            grid[i, j] = '.';
                        }
                    }
                }
            }
            Console.WriteLine(accessible);
            totalAccessible += accessible;
        }
        Console.WriteLine(totalAccessible);
    }
    
    private int IsDownRightRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i + 1, j + 1, grid);
    }

    private int IsDownLeftRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i + 1, j - 1, grid);
    }

    private int IsUpRightRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i - 1, j + 1, grid);
    }

    private int IsUpLeftRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i - 1, j - 1, grid);
    }

    private int IsDownRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i + 1, j, grid);
    }

    private int IsUpRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i - 1, j, grid);
    }

    private int IsRightRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i, j + 1, grid);
    }

    private int IsLeftRoll(char[,] grid, int i, int j)
    {
        return IsRoll(i , j - 1, grid);
    }

    private int IsRoll(int i, int j, char[,] grid)
    {
        try
        {
            var res = grid[i, j] == '@';
            if (res)
            {
                //Console.WriteLine($"{i},{j} is a roll");
                return 1;
            }

            return 0;
        }
        // exception based flow :ok:
        catch (Exception)
        {
            return 0;
        }
    }
}