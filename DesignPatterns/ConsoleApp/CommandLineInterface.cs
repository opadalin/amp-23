using System;

namespace ConsoleApp;

public class CommandLineInterface
{
    private readonly string _name;

    public CommandLineInterface(string name)
    {
        _name = name;
    }

    public void Run()
    {
        Welcome();
        bool quitApplication;
        do
        {
            quitApplication = InputController(ReadInput("Choose pattern: ").Trim());
        } while (!quitApplication);
    }

    private bool InputController(string input)
    {
        switch (input.ToLowerInvariant())
        {
            case "clear":
            case "cls":
                ClearConsole();
                break;
            case "q":
                return Quit();
            case "ls":
                ListAvailablePatterns();
                break;
            case "factory method":
                FactoryMethodProgram.Run();
                break;
            case "singleton":
                SingletonProgram.Run();
                break;
            default:
                Console.WriteLine("Not an available pattern");
                return false;
        }

        return false;
    }

    private static void ListAvailablePatterns()
    {
        Console.WriteLine("The available patterns to explore are: ");
        Console.WriteLine("\t- Singleton");
        Console.WriteLine("\t- Factory Method");
    }

    private static string ReadInput(string prompt)
    {
        string input;
        var counter = 0;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (IsEmpty());

        return input;

        bool IsEmpty()
        {
            var isEmpty = string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input) ||
                          input.Equals(Environment.NewLine);
            if (!isEmpty)
            {
                return true;
            }
            counter++;
            if (counter == 5)
            {
                Console.WriteLine("TIP: type 'ls' to see the patterns that are available");
                counter = 0;
            }
            else
            {
                Console.WriteLine("Please write something");
            }

            return false;
        }
    }

    private void Welcome()
    {
        Console.Title = _name;
        Console.WriteLine($"Welcome to {_name} command line interface");
        Console.WriteLine("Type 'q' to close the application at any time");
        Console.WriteLine("____________________________________________________");
    }

    private void ClearConsole()
    {
        Console.Clear();
        Welcome();
    }

    private static bool Quit()
    {
        var input = ReadInput("Close application? (Y/N): ");

        if (string.Equals(input, "y", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(input, "yes", StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine("closing..");
            return true;
        }


        return false;
    }
}