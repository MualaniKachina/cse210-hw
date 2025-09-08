using System;
using System.Collections.Generic;

class Job
{
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public Job(string company, string jobTitle, int startYear, int endYear)
    {
        Company = company;
        JobTitle = jobTitle;
        StartYear = startYear;
        EndYear = endYear;
    }

    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}

class Resume
{
    public string Name { get; set; }
    private List<Job> _jobs = new List<Job>();

    public Resume(string name)
    {
        Name = name;
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    public void Display()
    {
        Console.WriteLine($"\nResume for: {Name}");
        Console.WriteLine("Jobs:");
        if (_jobs.Count == 0)
        {
            Console.WriteLine("  (No jobs added yet)");
        }
        else
        {
            foreach (var job in _jobs)
            {
                job.Display();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Resume resume = new Resume(name);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nResume Menu:");
            Console.WriteLine("1. Add a job");
            Console.WriteLine("2. Display resume");
            Console.WriteLine("3. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter company name: ");
                    string company = Console.ReadLine();

                    Console.Write("Enter job title: ");
                    string jobTitle = Console.ReadLine();

                    Console.Write("Enter start year: ");
                    int startYear = int.Parse(Console.ReadLine());

                    Console.Write("Enter end year: ");
                    int endYear = int.Parse(Console.ReadLine());

                    Job job = new Job(company, jobTitle, startYear, endYear);
                    resume.AddJob(job);
                    Console.WriteLine("Job added!");
                    break;

                case "2":
                    resume.Display();
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
