using AdventOfCode.Utilities;

namespace AdventOfCode._2024._5;

public sealed class PartTwo : ICommand<int>
{
    public int Execute()
    {
        int total = 0;

        var (rulesStr, updatesStr) = ParseFile();

        // Use a HashSet for efficient rule lookup
        HashSet<(int, int)> rules = ConvertRulesToHashSet(rulesStr);
        var updates = updatesStr.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        List<int> currentUpdates = new();
        foreach (string update in updates)
        {
            var res = IsMatch(update, currentUpdates, rules);

            if (!res.Item1 && currentUpdates.Count % 2 != 0)
            {
                HandleMismatch(currentUpdates, rules);

                // Calculate and add the middle element
                int middle = currentUpdates[currentUpdates.Count / 2];
                total += middle;
            }

            currentUpdates.Clear();
        }

        return total;
    }

    private static (string, string) ParseFile()
    {
        string allText = File.ReadAllText(FilePathHelper.GetFilePath(5, FileType.Real));
        string[] allData = allText.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        if (allData.Length != 2)
            throw new InvalidOperationException("Unable to process");
        return (allData[0], allData[1]);
    }

    private static HashSet<(int, int)> ConvertRulesToHashSet(string rulesStr)
    {
        HashSet<(int, int)> rulesOutput = new();
        string[] rules = rulesStr.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (string rule in rules)
        {
            string[] split = rule.Split('|');
            if (split.Length == 2)
            {
                rulesOutput.Add((int.Parse(split[0]), int.Parse(split[1])));
            }
        }
        return rulesOutput;
    }

    private static (bool, int, int) IsMatch(string update, List<int> currentUpdates, HashSet<(int, int)> rules)
    {
        var u = update.Split(',', StringSplitOptions.RemoveEmptyEntries);
        currentUpdates.AddRange(u.Select(int.Parse));

        return CheckRules(currentUpdates, rules);
    }

    private static (bool, int, int) CheckRules(List<int> currentUpdates, HashSet<(int, int)> rules)
    {
        // Check pairs in currentUpdates against rules
        for (int i = 0; i < currentUpdates.Count - 1; i++)
        {
            for (int j = i + 1; j < currentUpdates.Count; j++)
            {
                if (!rules.Contains((currentUpdates[i], currentUpdates[j])))
                {
                    return (false, i, j);
                }
            }
        }
        return (true, -1, -1); // Match found
    }

    private static void HandleMismatch(List<int> currentUpdates, HashSet<(int, int)> rules)
    {
        while (true)
        {
            var res = CheckRules(currentUpdates, rules);

            if (res.Item1) // If it matches, exit the loop
                break;

            // Swap mismatched elements
            (currentUpdates[res.Item2], currentUpdates[res.Item3]) =
                (currentUpdates[res.Item3], currentUpdates[res.Item2]);
        }
    }
}