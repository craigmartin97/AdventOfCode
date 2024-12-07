using AdventOfCode._2024._2;

namespace AdventOfCode.UnitTests._2024._2;

public class PartTwoTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBeFour()
    {
        // Arrange
        PartTwo part = new();

        IEnumerable<int[]> reports = new List<int[]>
        {
            new[] { 7, 6, 4, 2, 1 },
            new[] { 1, 2, 7, 8, 9 },
            new[] { 9, 7, 6, 2, 1 },
            new[] { 1, 3, 2, 4, 5 },
            new[] { 8, 6, 4, 4, 1 },
            new[] { 1, 3, 6, 7, 9 }
        };

        // Act
        int sum = part.TotalSafeReports(reports);

        // Assert
        Assert.Equal(4, sum);
    }
}