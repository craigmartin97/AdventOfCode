using System.Collections.Immutable;

namespace AdventOfCode._2024._2;

public sealed class PartOne
{
    public int TotalSafeReports(IEnumerable<int[]> reports)
    {
        ArgumentNullException.ThrowIfNull(reports, nameof(reports));

        ImmutableArray<int[]> reportsArr = reports.ToImmutableArray();

        int count = 0;
        
        foreach (var report in reportsArr)
        {
            int prev = report[0];
            bool invalid = false;
            bool? startingTrend = null;

            for (var i = 1; i < report.Length; i++)
            {
                var current = report[i];
                int diff = Math.Abs(current - prev);
                bool isAscending = current > prev;

                if ((diff < 1 || diff > 3) || (startingTrend != null && startingTrend != isAscending))
                {
                    invalid = true;
                    break;
                }

                startingTrend = isAscending;
                prev = current;
            }

            if (!invalid)
            {
                count++;
            }
        }

        return count;
    }
}