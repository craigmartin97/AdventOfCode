using AdventOfCode._2024._1;
using AdventOfCode.Utilities;

namespace AdventOfCode.IntegrationTests._2024._1;

public sealed class PartTwoTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBe31()
    {
        // Arrange
        PartTwo dayOne = new();

        var fileParsed = TextFileParser<int>.ParseIntoSeparateColumns(FilePathHelper.GetFilePath(1),
            new[] { ' ', '\t' }, int.Parse);

        // Act
        long sum = dayOne.Execute(fileParsed[0], fileParsed[1]);

        // Assert
        Assert.Equal(31, sum);
    }
}