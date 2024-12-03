using AdventOfCode._2024._1;

namespace AdventOfCode.UnitTests._2024._1;

public sealed class DayOneTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBeEleven()
    {
        // Arrange
        DayOne dayOne = new();

        int[] listOne =
        {
            3, 4, 2, 1, 3, 3
        };
        int[] listTwo =
        {
            4, 3, 5, 3, 9, 3
        };

        // Act
        int sum = dayOne.Execute(listOne, listTwo);

        // Assert
        Assert.Equal(11, sum);
    }
}