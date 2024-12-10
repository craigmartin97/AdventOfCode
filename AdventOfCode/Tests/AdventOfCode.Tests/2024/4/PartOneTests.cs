using AdventOfCode._2024._4;
using FluentAssertions;

namespace AdventOfCode.UnitTests._2024._4;

public sealed class PartOneTests
{
    public void TotalXmasOccurrences_TenByTenGrid_Returns18()
    {
        // Arrange
        PartOne part = new();

        char[,] grid = new[,]
        {
            { 'M', 'M', 'M', 'S', 'X', 'X', 'M', 'A', 'S', 'M' },
            { 'M', 'S', 'A', 'M', 'X', 'M', 'S', 'M', 'S', 'A' },
            { 'A', 'M', 'X', 'S', 'X', 'M', 'A', 'A', 'M', 'M' },
            { 'M', 'S', 'A', 'M', 'A', 'S', 'M', 'S', 'M', 'X' },
            { 'X', 'M', 'A', 'S', 'A', 'M', 'X', 'A', 'M', 'M' },
            { 'X', 'X', 'A', 'M', 'M', 'X', 'X', 'A', 'M', 'A' },
            { 'S', 'M', 'S', 'M', 'S', 'A', 'S', 'X', 'S', 'S' },
            { 'S', 'A', 'X', 'A', 'M', 'A', 'S', 'A', 'A', 'A' },
            { 'M', 'A', 'M', 'M', 'M', 'X', 'M', 'M', 'M', 'M' },
            { 'M', 'X', 'M', 'X', 'A', 'X', 'M', 'A', 'S', 'X' }
        };

        int total = part.TotalXmasOccurrences(grid, "XMAS");

        // Act
        total.Should().Be(18);
    }
}