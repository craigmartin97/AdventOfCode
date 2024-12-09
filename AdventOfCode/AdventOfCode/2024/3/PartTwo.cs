using System.Text.RegularExpressions;

namespace AdventOfCode._2024._3;

public class PartTwo
{
    public int Sum(string input)
    {
        bool enabled = true;
        int sum = 0;

        // Regex pattern to match "mul(…), do(), and don't()"
        const string pattern = @"mul\([0-9]+,[0-9]+\)|do\(\)|don't\(\)";
        var matches = Regex.Matches(input, pattern);

        // Process each match
        foreach (Match match in matches)
        {
            string v = match.Value;

            switch (v)
            {
                case "do()":
                    enabled = true;
                    break;
                case "don't()":
                    enabled = false;
                    break;
                default:
                {
                    if (enabled && v.StartsWith("mul("))
                    {
                        // Extract numbers inside "mul(…)"
                        string[] numbers = v[4..^1].Split(',');

                        // Compute the product of the numbers
                        int product = numbers.Aggregate(1, (current, num) => current * int.Parse(num));

                        sum += product;
                    }

                    break;
                }
            }
        }

        return sum;
    }
}