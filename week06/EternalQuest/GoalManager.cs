using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int Score => _score;
    public int GoalCount => _goals.Count;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].Display();
        }
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        _goals[index].RecordEvent();

        // Update score based on goal type
        _score += _goals[index].Points;

        // If it's a checklist goal and completed, add bonus points
        if (_goals[index] is ChecklistGoal checklistGoal && checklistGoal.IsComplete)
        {
            _score += checklistGoal.BonusPoints;
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetType().Name);
                writer.WriteLine(goal.Name);
                writer.WriteLine(goal.Description);
                writer.WriteLine(goal.Points);
                writer.WriteLine(goal.IsComplete);

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine(checklistGoal.TimesCompleted);
                    writer.WriteLine(checklistGoal.TimesRequired);
                    writer.WriteLine(checklistGoal.BonusPoints);
                }
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());

            while (!reader.EndOfStream)
            {
                string goalType = reader.ReadLine();
                string name = reader.ReadLine();
                string description = reader.ReadLine();
                int points = int.Parse(reader.ReadLine());
                bool isComplete = bool.Parse(reader.ReadLine());

                Goal goal = null;

                if (goalType == nameof(SimpleGoal))
                {
                    goal = new SimpleGoal(name, description, points);
                }
                else if (goalType == nameof(EternalGoal))
                {
                    goal = new EternalGoal(name, description, points);
                }
                else if (goalType == nameof(ChecklistGoal))
                {
                    int timesCompleted = int.Parse(reader.ReadLine());
                    int timesRequired = int.Parse(reader.ReadLine());
                    int bonusPoints = int.Parse(reader.ReadLine());

                    goal = new ChecklistGoal(name, description, points, timesRequired, bonusPoints);
                    ((ChecklistGoal)goal).SetProgress(timesCompleted, isComplete);
                }

                if (goal != null)
                {
                    if (isComplete)
                        goal.MarkComplete();

                    _goals.Add(goal);
                }
            }
        }
    }
}
