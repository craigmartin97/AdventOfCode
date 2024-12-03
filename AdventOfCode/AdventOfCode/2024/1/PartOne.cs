using System.Collections.Immutable;

namespace AdventOfCode._2024._1;

public sealed class PartOne
{
    public int Execute(IEnumerable<int> listOne, IEnumerable<int> listTwo)
    {
        ArgumentNullException.ThrowIfNull(listOne, nameof(listOne));
        ArgumentNullException.ThrowIfNull(listTwo, nameof(listTwo));

        ImmutableArray<int> listOneArr = listOne.ToImmutableArray();
        ImmutableArray<int> listTwoArr = listTwo.ToImmutableArray();

        if (listOneArr.Length != listTwoArr.Length)
        {
            throw new InvalidOperationException("The two lists are not the same length");
        }

        listOneArr = listOneArr.Sort();
        listTwoArr = listTwoArr.Sort();

        int sum = 0;
        for (int i = 0; i < listOneArr.Length; i++)
        {
            int smallestFromListOne = listOneArr[i];
            int smallestFromListTwo = listTwoArr[i];
            sum += Math.Abs(smallestFromListTwo - smallestFromListOne);
        }

        return sum;
    }
}