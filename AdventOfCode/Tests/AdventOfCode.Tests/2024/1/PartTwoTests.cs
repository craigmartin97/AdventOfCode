using AdventOfCode._2024._1;

namespace AdventOfCode.UnitTests._2024._1;

public sealed class PartTwoTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBeEleven()
    {
        // Arrange
        PartTwo partTwo = new();

        int[] listOne =
        {
            3, 4, 2, 1, 3, 3
        };
        int[] listTwo =
        {
            4, 3, 5, 3, 9, 3
        };

        // Act
        long sum = partTwo.Execute(listOne, listTwo);

        // Assert
        Assert.Equal(31, sum);
    }
}