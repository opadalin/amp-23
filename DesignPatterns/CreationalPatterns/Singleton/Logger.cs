using System;

namespace CreationalPatterns.Singleton;

/// <summary>
/// Singleton
/// </summary>
public class Logger
{
    private static Logger _instance;

    private Logger()
    {
    }

    public static Logger Instance => _instance ??= new Logger();

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}