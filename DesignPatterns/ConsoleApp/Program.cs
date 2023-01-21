using System;
using CreationalPatterns;

Console.Title = "Singleton pattern";

var logger1 = Logger.Instance;
var logger2 = Logger.Instance;

logger1.Log("Hej");