namespace AdventOfCode.Utilities;

public static class StringExtensions
{
    public static char[,] ConvertToCharGrid(this string[] input)
    {
        int rows = input.Length;
        int cols = input[0].Length;
        char[,] grid = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = input[i][j];
            }
        }

        return grid;
    }
}