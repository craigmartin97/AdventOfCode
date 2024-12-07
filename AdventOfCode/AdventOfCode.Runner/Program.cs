// See https://aka.ms/new-console-template for more information

using AdventOfCode._2024._2;
using AdventOfCode.Utilities;

Console.WriteLine("Running solution!");

int day = DateTime.Now.Day; // change if doing puzzle that isn't today's 
string fileLocation = FilePathHelper.GetFilePath(day, FileType.Real);

var lists = TextFileParser<int>.ParseAsRows(fileLocation, new []{ ' ', '\t' }, int.Parse );

PartTwo part = new();
int sum = part.TotalSafeReports(lists);

Console.WriteLine(sum);