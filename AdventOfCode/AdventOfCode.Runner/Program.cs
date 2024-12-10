// See https://aka.ms/new-console-template for more information

using AdventOfCode._2024._4;
using AdventOfCode.Utilities;

Console.WriteLine("Running solution!");

// int day = DateTime.Now.Day; // change if doing puzzle that isn't today's
const int day = 4;
string fileLocation = FilePathHelper.GetFilePath(day, FileType.Test);

var input = File.ReadAllLines(fileLocation);
PartTwo part = new();
int total = part.TotalMasStarOccurrences(input.ConvertToCharGrid());

Console.WriteLine(total);