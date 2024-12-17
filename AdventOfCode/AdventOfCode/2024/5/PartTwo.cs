using AdventOfCode.Utilities;

namespace AdventOfCode._2024._5;

public sealed class PartTwo : ICommand<int>
{
    public int Execute()
    {
        int total = 0;

        var (rulesStr, updatesStr) = ParseFile();

        List<(int, int)> rules = ConvertRulesToTuples(rulesStr);
        var updates = updatesStr.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        List<int> currentUpdates = new();
        foreach (string update in updates)
        {
            var res = IsMatch(update, currentUpdates, rules);

            if (!res.Item1 && currentUpdates.Count % 2 != 0)
            {
                HandleMismatchRecursive(currentUpdates, res.Item2, res.Item3, rules);

                int middle = currentUpdates.ElementAt(currentUpdates.Count / 2);
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
            throw new InvalidOperationException("unable to process");
        string rules = allData[0];
        string updates = allData[1];
        return (rules, updates);
    }

    private static List<(int, int)> ConvertRulesToTuples(string rulesStr)
    {
        List<(int, int)> tuples = new List<(int, int)>();
        string[] rules = rulesStr.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (string rule in rules)
        {
            string[] split = rule.Split('|');
            if (split.Length != 2)
                continue;
            tuples.Add((int.Parse(split[0]), int.Parse(split[1])));
        }
        return tuples;
    }

    private static (bool, int, int) IsMatch(string update, List<int> currentUpdates, 
        List<(int, int)> rules)
    {
        var u = update.Split(',', StringSplitOptions.RemoveEmptyEntries);
        currentUpdates.AddRange(u.Select(int.Parse));

        bool match = true;
        int i;
        int j = 0;

        for (i = 0; i < currentUpdates.Count - 1; i++)
        {
            int x = currentUpdates.ElementAt(i);

            for (j = i + 1; j < currentUpdates.Count; j++)
            {
                int y = currentUpdates.ElementAt(j);
                match = rules.Exists(tuple => tuple.Item1 == x && tuple.Item2 == y);
                if (!match)
                {
                    return (match, i, j);
                }
            }
        }

        return (match, i ,j);
    }

    private static (bool, int, int) IsMatch(IReadOnlyCollection<int> currentUpdates, List<(int, int)> rules)
    {
        bool match = true;
        int i;
        int j = 0;

        for (i = 0; i < currentUpdates.Count - 1; i++)
        {
            int x = currentUpdates.ElementAt(i);

            for (j = i + 1; j < currentUpdates.Count; j++)
            {
                int y = currentUpdates.ElementAt(j);
                match = rules.Exists(tuple => tuple.Item1 == x && tuple.Item2 == y);
                if (!match)
                {
                    return (match, i, j);
                }
            }
        }

        return (match, i, j);
    }

    private static void HandleMismatchRecursive(List<int> currentUpdates, int index1, int index2, List<(int, int)> rules)
    {
        // Swap elements
        (currentUpdates[index1], currentUpdates[index2]) = (currentUpdates[index2], currentUpdates[index1]);

        // Re-check if the list matches the rules
        var res = IsMatch(currentUpdates, rules);

        // If still no match, call the method recursively
        if (!res.Item1)
        {
            HandleMismatchRecursive(currentUpdates, res.Item2, res.Item3, rules);
        }
    }
}