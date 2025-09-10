/*
How My Program Exceeds the Core Requirements

1. Separation of Concerns
   - Instead of keeping all logic inside Main(), I used separate classes (Journal, Entry, and PromptGenerator) 
     to handle different parts of the program.
   - This makes the program easier to maintain, extend, and reuse.

2. Randomized Prompts
   - The program doesn’t just ask for free-form entries — it generates a random writing prompt with PromptGenerator.GetRandomPrompt().
   - This adds variety and makes journaling more engaging, which was beyond the minimum requirements.

3. File Handling (Save & Load)
   - The journal entries can be saved to a file and loaded back later.
   - This persistence feature allows users to keep their writing between sessions, going beyond just temporary in-memory storage.

4. User-Friendly Menu System
   - A clear menu loop (while (running)) is implemented so the user can continuously interact with the program without restarting it.
   - Input validation is also included for wrong menu choices (default: Console.WriteLine("Invalid choice.")).

5. Timestamps for Entries
   - Each entry automatically records the current date (DateTime.Now.ToShortDateString()), 
     adding useful context to journal entries without requiring extra effort from the user.

In short: My program not only meets the core requirements (write, display, save, load, quit), 
but also improves usability, structure, and functionality with random prompts, file persistence, 
error handling, and organized code design.
*/

using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry entry = new Entry(date, prompt, response);
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
