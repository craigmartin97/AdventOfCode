// See https://aka.ms/new-console-template for more information

using AdventOfCode._2024._3;
using AdventOfCode.Utilities;

Console.WriteLine("Running solution!");

// int day = DateTime.Now.Day; // change if doing puzzle that isn't today's
const int day = 3;
string fileLocation = FilePathHelper.GetFilePath(day, FileType.Real);

var input = File.ReadAllText(fileLocation);

PartTwo part = new();
int sum = part.Sum(input);

Console.WriteLine(sum);