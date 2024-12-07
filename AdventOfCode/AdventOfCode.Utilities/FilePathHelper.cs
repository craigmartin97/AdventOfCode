namespace AdventOfCode.Utilities;

public enum FileType
{
    Test,
    Real,
}

public static class FilePathHelper
{
    public static string GetFilePath(int day, FileType type = FileType.Test)
    {
        string fileName = type == FileType.Test ? "test" : "input";
        return $"E:\\Projects\\AdventOfCode\\AdventOfCode\\Inputs\\2024\\{day}\\{fileName}.txt";
    }
}