using System;
using CreationalPatterns;

Console.Title = "Singleton pattern";

var logger1 = Logger.Instance;
var logger2 = Logger.Instance;

if (logger1 == logger2 && logger2 == Logger.Instance)
{
    logger1.Log("Instances are the same.");
}

logger1.Log($"Message from {nameof(logger1)}");
logger2.Log($"Message from {nameof(logger2)}");

Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");
