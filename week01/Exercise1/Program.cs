using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your favorite color: ");
        string color = Console.ReadLine();

        Console.WriteLine($"Nice to meet you, {name}. {color} is a great color!");
    }
}
