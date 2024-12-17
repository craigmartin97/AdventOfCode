using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AdventOfCode.Benchmarking._5;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public sealed class PartOne
{
    private readonly _2024._5.PartOne _part;

    public PartOne()
    {
        _part = new _2024._5.PartOne();
    }

    [Benchmark]
    public void Execute()
    {
        _part.Execute();
    }
}