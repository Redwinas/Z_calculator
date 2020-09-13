using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalc_Z
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculatorOperations calculator = new Calculator(); // Set ups the calculator
            Console.WriteLine("Please Input command or write 'help' for information");
            bool exit = false;
            while (!exit)
            {
                var line = Console.ReadLine().ToLower();
                switch (true) // Command input switch cases
                {
                    case true when Regex.Match(line, "exit").Success:
                        exit = true;
                        break;
                    case true when Regex.Match(line, "push [0-9]+").Success: // Checks if text input is push and some positive number
                        if (calculator.Count() < calculator.Size())
                        {
                            Regex regex = new Regex("[0-9]+");
                            int number = int.Parse(regex.Matches(line)[0].Value.Trim(' '));
                            calculator.Push(number);
                            Console.WriteLine("Pushed; Number = "+ calculator.Peek());
                        }
                        else
                        {
                            //throw new InvalidOperationException("Error: Stack overfilled");
                            Console.WriteLine("Error: Stack overfilled");
                        }
                        break;
                    case true when Regex.Match(line, "add").Success: // Add two top most values
                        if (calculator.Count() >= 2)
                        {
                            int result = calculator.Add();
                            Console.WriteLine("Added; Result = "+ result);
                        }
                        else
                        {
                            //throw new InvalidOperationException("Error: Stack does not contain 2 or more values.");
                            Console.WriteLine("Error: Stack does not contain 2 or more values.");
                        }
                        break;
                    case true when Regex.Match(line, "pop").Success: // Pops out the top most value
                        if (calculator.Count() != 0)
                        {
                            int result = calculator.Pop();
                            Console.WriteLine("Popped; Result = " + result);
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty");
                        }
                        break;
                    case true when Regex.Match(line, "sub").Success: // Subdivide top most values
                        if (calculator.Count() >= 2)
                        {
                            int result = calculator.Sub();
                            Console.WriteLine("Subdivided; Result = "+ result);
                        }
                        else
                        {
                            //throw new InvalidOperationException("Error: Stack does not contain 2 or more values.");
                            Console.WriteLine("Error: Stack does not contain 2 or more values.");
                        }
                        break;
                    case true when Regex.Match(line, "help").Success: // Help command
                        ShowHelp();
                        break;
                    case true when Regex.Match(line, "clear").Success: // Console clear command
                        Console.Clear();
                        Console.WriteLine("Please Input command or write 'help' for information");
                        break;
                    case true when Regex.Match(line, "stack").Success: // Stack print out command
                        Console.WriteLine(calculator.ToString());
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        /// <summary>
        /// Prints out the help information
        /// </summary>
        static void ShowHelp()
        {
            Console.WriteLine("Push <number> - push number onto the stack");
            Console.WriteLine("Pop - removes top most number from stack");
            Console.WriteLine("Add - removes top most numbers, adds them, result is pushed back to stack");
            Console.WriteLine("Sub - removes top most numbers, subdivides them, result is pushed back to stack");
            Console.WriteLine("Stack - prints out the stack values");
            Console.WriteLine("exit - ends program");
            Console.WriteLine("clear - clears console window");
        }
    }
}
