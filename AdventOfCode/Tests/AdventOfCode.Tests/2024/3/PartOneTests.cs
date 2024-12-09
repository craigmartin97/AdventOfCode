using AdventOfCode._2024._3;
using FluentAssertions;

namespace AdventOfCode.UnitTests._2024._3;

public class PartOneTests
{
    [Fact]
    public void SumUsingStringSplitting_WithExampleData_Expected161()
    {
        // Arrange
        PartOne part = new();

        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        // Act
        int sum = part.Sum_UsingStringSplitting(input);

        // Assert
        sum.Should().Be(161);
    }

    [Fact]
    public void SumUsingRegex_WithExampleData_Expected161()
    {
        // Arrange
        PartOne part = new();

        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        // Act
        int sum = part.Sum_UsingRegex(input);

        // Assert
        sum.Should().Be(161);
    }
}