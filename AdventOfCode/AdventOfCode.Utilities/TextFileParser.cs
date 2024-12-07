namespace AdventOfCode.Utilities;

public static class TextFileParser<T>
{
    /// <summary>
    /// Parse each column into separate lists
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="delimiters">what to split on</param>
    /// <param name="parseFunc"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="FormatException"></exception>
    public static List<List<T>> ParseIntoSeparateColumns(string filePath, char[] delimiters, Func<string, T> parseFunc)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("Unable to find the file. Validate that it exists.", nameof(filePath));
        }

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            throw new InvalidOperationException("");
        }

        // List to temporarily hold lists of the specified type
        List<List<T>> tempLists = new List<List<T>>();

        foreach (var line in lines)
        {
            // Split the line by whitespace and remove empty entries
            string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // If no lists have been created yet, initialize them based on the line's parts
            if (tempLists.Count == 0)
            {
                // Create a list for each part of the first line
                tempLists.AddRange(parts.Select(part => new List<T>()));
            }

            // Check if the current line has the same number of elements as the first line
            if (parts.Length != tempLists.Count)
            {
                throw new FormatException($"Line has an incorrect number of elements: '{line}'");
            }

            // Parse the elements using the provided parsing function and add them to the respective lists
            for (int i = 0; i < parts.Length; i++)
            {
                tempLists[i].Add(parseFunc(parts[i]));
            }
        }

        return tempLists;
    }

    public static List<T[]> ParseAsRows(string filePath, char[] delimiters, Func<string, T> parseFunc)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("Unable to find the file. Validate that it exists.", nameof(filePath));
        }

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            throw new InvalidOperationException("");
        }

        // List to temporarily hold lists of the specified type
        List<T[]> tempLists = new List<T[]>();
        foreach (var line in lines)
        {
            // Split the line by whitespace and remove empty entries
            string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            T[] arr = new T[parts.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = parseFunc(parts[i]);
            }
            tempLists.Add(arr);
        }

        return tempLists;
    }
}