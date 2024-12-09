using System.Text.RegularExpressions;

namespace AdventOfCode._2024._3;

public sealed class PartOne
{
    // Optimal solution
    public int Sum_UsingStringSplitting(string input)
    {
        int sum = 0;

        string[] splits = input.Split("mul(");
        foreach (var split in splits)
        {
            int end = split.IndexOf(')');

            if (end <= -1) 
                continue;
            
            string extract = split.Substring(0, end);
            if (!extract.Contains(',')) 
                continue;

            var s = extract.Split(',');
            if(s.Length != 2) 
                continue;

            // This is a valid case to multiply
            bool isOneNum = int.TryParse(s[0], out int numOne);
            bool isTwoNum = int.TryParse(s[1], out int numTwo);
            if (isOneNum && isTwoNum)
            {
                if(numOne > 999 || numTwo > 999)
                    continue;
                sum += numOne * numTwo;
            }
        }

        return sum;
    }

    public int Sum_UsingRegex(string input)
    {
        int ans = 0;

        // Regex pattern to match "mul(…), do(), and don't()"
        const string pattern = @"mul\([0-9]+,[0-9]+\)";
        var matches = Regex.Matches(input, pattern);

        // Process each match
        foreach (Match match in matches)
        {
            string v = match.Value;

            // Extract numbers inside "mul(…)"
            string[] numbers = v.Substring(4, v.Length - 5).Split(',');

            // Compute the product of the numbers
            int product = 1;
            foreach (string num in numbers)
            {
                product *= int.Parse(num);
            }

            ans += product;
        }

        return ans;
    }
}