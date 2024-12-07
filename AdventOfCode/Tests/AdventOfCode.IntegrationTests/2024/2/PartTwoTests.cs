using AdventOfCode._2024._2;
using AdventOfCode.Utilities;

namespace AdventOfCode.IntegrationTests._2024._2;

public class PartTwoTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBe2()
    {
        // Arrange
        PartTwo part = new();

        var fileParsed = TextFileParser<int>.ParseAsRows(FilePathHelper.GetFilePath(2),
            new[] { ' ', '\t' }, int.Parse);

        // Act
        int sum = part.TotalSafeReports(fileParsed);

        // Assert
        Assert.Equal(4, sum);
    }
}