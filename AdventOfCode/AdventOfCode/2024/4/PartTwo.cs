namespace AdventOfCode._2024._4;

public sealed class PartTwo
{
    public int TotalMasStarOccurrences(char[,] grid)
    {
        if (grid.Length == 0)
            throw new InvalidOperationException("The input has no lines to analyze");

        int rows = grid.GetLength(0);
        int columns = grid.GetLength(1);
        int totalXmasOccurrences = 0;

        for (int i = 1; i < rows - 1; i++) // no need to check the first or last row
        {
            for (int j = 0; j < columns; j++)
            {
                if (grid[i, j] != 'A') continue;

                // out of bounds
                if (i - 1 < 0 || i + 1 >= grid.GetLength(0) ||
                    j - 1 < 0 || j + 1 >= grid.GetLength(1))
                {
                    continue;
                }

                // in bounds, grab the chars in diagonals
                var previousRowLeft = grid[i-1, j-1];
                var previousRowRight = grid[i-1, j+1];
                var belowRowLeft = grid[i+1, j-1];
                var belowRowRight = grid[i+1, j+1];
                if (IsMatch(previousRowLeft, previousRowRight, belowRowLeft, belowRowRight))
                {
                    totalXmasOccurrences++;
                }
            }
        }

        return totalXmasOccurrences;
    }

    private static bool IsMatch(char previousRowLeft, char previousRowRight, char belowRowLeft, char belowRowRight)
    {
        int count = 0;
        if (previousRowLeft == 'M' && belowRowRight == 'S')
        {
            count++;
        }

        if (previousRowRight == 'M' && belowRowLeft == 'S')
        {
            count++;
        }

        if (belowRowLeft == 'M' && previousRowRight == 'S')
        {
            count++;
        }

        if (belowRowRight == 'M' && previousRowLeft == 'S')
        {
            count++;
        }

        return count == 2;
    }
}