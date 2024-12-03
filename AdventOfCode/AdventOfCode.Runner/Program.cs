// See https://aka.ms/new-console-template for more information

using AdventOfCode._2024._1;
using AdventOfCode.Utilities;

Console.WriteLine("Running solution!");

string fileLocation = "E:\\Projects\\AdventOfCode\\AdventOfCode\\Inputs\\2024\\1\\input.txt";

var lists = TextFileParser<int>.ParseFile(fileLocation, new []{ ' ', '\t' }, int.Parse );

PartTwo dayOne =  new PartTwo();
long sum = dayOne.Execute(lists[0], lists[1]);

Console.WriteLine(sum);