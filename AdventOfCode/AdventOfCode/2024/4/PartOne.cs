namespace AdventOfCode._2024._4;

public sealed class PartOne
{
    private readonly int[,] _directions = {
        { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }, // Horizontal and vertical
        { 1, 1 }, { -1, -1 }, { 1, -1 }, { -1, 1 } // Diagonal
    };

    public int TotalXmasOccurrences(char[,] grid, string word)
    {
        if (grid.Length == 0)
            throw new InvalidOperationException("The input has no lines to analyze");

        int rows = grid.GetLength(0);
        int columns = grid.GetLength(1);
        int totalXmasOccurrences = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (grid[i, j] != word[0]) continue;
                for (int d = 0; d < _directions.GetLength(0); d++)
                {
                    int dx = _directions[d, 0];
                    int dy = _directions[d, 1];
                    if (DepthFirstSearch(grid, word, i, j, 0, dx, dy))
                    {
                        totalXmasOccurrences++;
                    }
                }
            }
        }

        return totalXmasOccurrences;
    }

    private static bool DepthFirstSearch(char[,] grid, string word,
        int rowIndex, int columnIndex, int wordPositionIndex, int dx, int dy)
    {
        if (wordPositionIndex == word.Length)
            return true;

        if (rowIndex < 0 || rowIndex >= grid.GetLength(0) ||
            columnIndex < 0 || columnIndex >= grid.GetLength(1) ||
            grid[rowIndex, columnIndex] != word[wordPositionIndex])
        {
            return false;
        }

        // Move in the current direction
        return DepthFirstSearch(grid, word, rowIndex + dx, columnIndex + dy, wordPositionIndex + 1, dx, dy);
    }
}