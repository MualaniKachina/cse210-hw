using System;

class Program
{
    static void Main()
    {
        int total = 0;
        int number;

        Console.WriteLine("Enter numbers to add them together. Enter 0 to finish.");

        do
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            total += number;
        } 
        while (number != 0);

        Console.WriteLine($"The total sum is: {total}");
    }
}
