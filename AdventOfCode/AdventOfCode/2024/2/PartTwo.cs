using System.Collections.Immutable;

namespace AdventOfCode._2024._2;

public class PartTwo
{
    public int TotalSafeReports(IEnumerable<int[]> reports)
    {
        ArgumentNullException.ThrowIfNull(reports, nameof(reports));

        ImmutableArray<int[]> reportsArr = reports.ToImmutableArray();

        int count = 0;

        foreach (var report in reportsArr)
        {
            // Check if removing one level can make the report safe
            for (int i = 0; i < report.Length; i++)
            {
                var modifiedReport = report.Where((_, index) => index != i).ToArray();
                if (!IsReportSafe(modifiedReport)) continue;
                count++;
                break; // No need to check further once it's confirmed safe
            }
        }

        return count;
    }

    private static bool IsReportSafe(IReadOnlyList<int> report)
    {
        if (report.Count < 2)
            return true;

        int prev = report[0];
        bool? startingTrend = null;

        for (var i = 1; i < report.Count; i++)
        {
            var current = report[i];
            int diff = Math.Abs(current - prev);
            bool isAscending = current > prev;

            if ((diff < 1 || diff > 3) || (startingTrend != null && startingTrend != isAscending))
            {
                return false; // Unsafe if any condition is violated
            }

            startingTrend = isAscending;
            prev = current;
        }

        return true; // Safe if no violations are found
    }
}