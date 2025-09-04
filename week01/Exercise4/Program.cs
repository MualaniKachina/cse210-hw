using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> names = new List<string>();
        string input;

        Console.WriteLine("Enter names one by one. Type 'stop' to finish.");

        while (true)
        {
            Console.Write("Enter a name: ");
            input = Console.ReadLine();

            if (input.ToLower() == "stop")
            {
                break;
            }

            names.Add(input);
        }

        Console.WriteLine("\nYou entered these names:");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
