// See https://aka.ms/new-console-template for more information

using AdventOfCode.Utilities;
using PartOne = AdventOfCode._2024._4.PartOne;

Console.WriteLine("Running solution!");

// int day = DateTime.Now.Day; // change if doing puzzle that isn't today's
const int day = 4;
string fileLocation = FilePathHelper.GetFilePath(day, FileType.Test);

var input = File.ReadAllLines(fileLocation);
PartOne part = new();
int total = part.TotalXmasOccurrences(input.ConvertToCharGrid(), "XMAS");

Console.WriteLine(total);