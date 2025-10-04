using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // 🌟 Creative Additions 🌟
        // Preloaded goals simulate a real-life scenario (health, spiritual, social)
        // Variety of goal types encourages different types of engagement
        // Adds gamification elements like scoring and checklist bonuses

        // Fun welcome message to engage the user
        Console.WriteLine("=====================================");
        Console.WriteLine("   Welcome to the Eternal Quest! 🎯  ");
        Console.WriteLine(" Track your goals. Earn points. Win. ");
        Console.WriteLine("=====================================\n");

        // Add initial goals to the manager
        goalManager.AddGoal(new SimpleGoal("Run Marathon", "Complete a full marathon", 1000));
        goalManager.AddGoal(new EternalGoal("Read Scriptures", "Read scriptures daily", 100));
        goalManager.AddGoal(new ChecklistGoal("Attend Temple", "Attend temple 10 times", 50, 10, 500));

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Eternal Quest Menu ---");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.DisplayGoals();
                    Console.WriteLine($"💡 Total Score: {goalManager.Score} points");
                    break;

                case "2":
                    Console.Write("Enter goal number to record event: ");
                    if (int.TryParse(Console.ReadLine(), out int goalNumber) &&
                        goalNumber > 0 && goalNumber <= goalManager.GoalCount)
                    {
                        goalManager.RecordEvent(goalNumber - 1);
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid goal number.");
                    }
                    break;

                case "3":
                    goalManager.SaveGoals("goals.txt");
                    Console.WriteLine("✅ Goals saved!");
                    break;

                case "4":
                    goalManager.LoadGoals("goals.txt");
                    Console.WriteLine("📂 Goals loaded!");
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("👋 Goodbye! Stay motivated and keep striving!");
                    break;

                default:
                    Console.WriteLine("⚠️ Invalid option, try again.");
                    break;
            }
        }
    }
}
