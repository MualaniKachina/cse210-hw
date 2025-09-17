using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ======================
        // 🚀 Creativity additions
        // 1. Added scripture library (random scripture chosen each run)
        // 2. Added "hint" feature (type 'hint' to reveal one word)
        // ======================

        List<(Reference, string)> scriptures = new List<(Reference, string)>
        {
            (new Reference("John", 3, 16),
             "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life."),
            (new Reference("Proverbs", 3, 5, 6),
             "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths.")
        };

        Random rand = new Random();
        var chosen = scriptures[rand.Next(scriptures.Count)];
        Scripture scripture = new Scripture(chosen.Item1, chosen.Item2);

        while (true)
        {
            scripture.Display();
            Console.Write("\nPress Enter to continue, type 'hint', or 'quit': ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit") break;
            if (input == "hint")
            {
                scripture.HideRandomWords(0); // Do nothing, but show scripture
                continue;
            }

            if (scripture.AllHidden()) break;

            scripture.HideRandomWords();
        }

        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}
