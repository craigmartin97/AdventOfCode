﻿using AdventOfCode._2024._1;
using AdventOfCode.Utilities;

namespace AdventOfCode.IntegrationTests._2024._1;

public sealed class PartOneTests
{
    [Fact]
    public void Execute_WithExampleData_ExpectedSumToBe11()
    {
        // Arrange
        PartOne dayOne = new();

        var fileParsed = TextFileParser<int>.ParseFile("E:\\Projects\\AdventOfCode\\AdventOfCode\\Inputs\\2024\\1\\test.txt",
            new[] { ' ', '\t' }, int.Parse);

        // Act
        int sum = dayOne.Execute(fileParsed[0], fileParsed[1]);

        // Assert
        Assert.Equal(11, sum);
    }
}