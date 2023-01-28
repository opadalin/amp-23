using CreationalPatterns.Singleton;

namespace ConsoleApp;

public static class SingletonProgram
{
    public static void Run()
    {
        var logger1 = LazyLogger.Instance;
        var logger2 = LazyLogger.Instance;

        if (logger1 == logger2 && logger2 == LazyLogger.Instance)
        {
            logger1.Log("Instances are the same.");
        }

        logger1.Log($"Message from {nameof(logger1)}");
        logger2.Log($"Message from {nameof(logger2)}");

        LazyLogger.Instance.Log($"Message from {nameof(LazyLogger.Instance)}");
    }
}