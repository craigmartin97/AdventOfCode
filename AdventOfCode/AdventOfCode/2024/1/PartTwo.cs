using System.Collections.Immutable;

namespace AdventOfCode._2024._1;

public sealed class PartTwo
{
    public long Execute(IEnumerable<int> listOne, IEnumerable<int> listTwo)
    {
        ArgumentNullException.ThrowIfNull(listOne, nameof(listOne));
        ArgumentNullException.ThrowIfNull(listTwo, nameof(listTwo));

        ImmutableArray<int> listOneArr = listOne.ToImmutableArray();
        ImmutableArray<int> listTwoArr = listTwo.ToImmutableArray();

        if (listOneArr.Length != listTwoArr.Length)
        {
            throw new InvalidOperationException("The two lists are not the same length");
        }

        var two= Frequency(listTwoArr.GroupBy(x => x));

        long sum = 0;
        foreach (var i in listOneArr)
        {
            if (two.TryGetValue(i, out long v))
            {
                sum += (i * v);
            }
        }

        return sum;
    }

    private static Dictionary<int, long> Frequency(IEnumerable<IGrouping<int, int>> group)
    {
        var groupArr = group.ToArray();
        return groupArr.ToDictionary<IGrouping<int, int>, int, long>(g => g.Key, g => g.Count());
    }
}