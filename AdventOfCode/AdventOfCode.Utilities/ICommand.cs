namespace AdventOfCode.Utilities;

public interface ICommand<out T>
{
    T Execute();
}