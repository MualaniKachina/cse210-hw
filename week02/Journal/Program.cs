using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    class Entry
    {
        public string _prompt;
        public string _response;
        public string _date;

        public Entry(string prompt, string response)
        {
            _prompt = prompt;
            _response = response;
            _date = DateTime.Now.ToShortDateString();
        }

        public override string ToString()
        {
            return $"{_date} - Prompt: {_prompt}\nResponse: {_response}";
        }
    }

    class Journal
    {
        private List<Entry> _entries = new();

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries to display.");
                return;
            }

            foreach (var entry in _entries)
            {
                Console.WriteLine(entry);
                Console.WriteLine();
            }
        }

        public void SaveToFile(string filename)
        {
            using StreamWriter writer = new(filename);
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            _entries.Clear();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    var entry = new Entry(parts[1], parts[2])
                    {
                        _date = parts[0]
                    };
                    _entries.Add(entry);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new();

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry entry = new Entry(prompt, response);
                    journal.AddEntry(entry);

                    Console.WriteLine("Entry added!\n");
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save journal: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.\n");
                    break;

                case "4":
                    Console.Write("Enter filename to load journal: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.\n");
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }
    }
}
