using System;

namespace CreationalPatterns.Singleton;

/// <summary>
/// Logger
/// </summary>
public class LazyLogger
{

    private static readonly Lazy<LazyLogger> Logger = new(() => new LazyLogger());

    private LazyLogger()
    {
    }

    public static LazyLogger Instance => Logger.Value;

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}