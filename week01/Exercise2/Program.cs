using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your test score (0–100): ");
        string input = Console.ReadLine();
        int score = int.Parse(input);

        if (score >= 90)
        {
            Console.WriteLine("You got an A!");
        }
        else if (score >= 80)
        {
            Console.WriteLine("You got a B!");
        }
        else if (score >= 70)
        {
            Console.WriteLine("You got a C.");
        }
        else if (score >= 60)
        {
            Console.WriteLine("You got a D.");
        }
        else
        {
            Console.WriteLine("You got an F.");
        }
    }
}
