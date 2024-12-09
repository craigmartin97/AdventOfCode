using AdventOfCode.Utilities;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AdventOfCode.Benchmarking._3;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class PartOne
{
    private readonly _2024._3.PartOne _part;
    private readonly string _input = File.ReadAllText(FilePathHelper.GetFilePath(3, FileType.Real));

    public PartOne()
    {
        _part = new _2024._3.PartOne();
    }

    [Benchmark]
    public void Sum_UsingStringSplits()
    {
        _part.Sum_UsingStringSplitting(_input);
    }

    [Benchmark]
    public void Sum_UsingRegex()
    {
        _part.Sum_UsingRegex(_input);
    }
}