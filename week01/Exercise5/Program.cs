using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());

        int result = AddNumbers(num1, num2);

        Console.WriteLine($"The sum of {num1} and {num2} is {result}.");
    }

    // Function to add two numbers
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }
}
