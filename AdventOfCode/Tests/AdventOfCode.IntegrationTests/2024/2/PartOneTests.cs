using AdventOfCode._2024._2;
using AdventOfCode.Utilities;

namespace AdventOfCode.IntegrationTests._2024._2;

public class PartOneTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBe2()
    {
        // Arrange
        PartOne part = new();

        var fileParsed = TextFileParser<int>.ParseAsRows(FilePathHelper.GetFilePath(2),
            new[] { ' ', '\t' }, int.Parse);

        // Act
        int sum = part.TotalSafeReports(fileParsed);

        // Assert
        Assert.Equal(2, sum);
    }
}