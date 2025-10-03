using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public bool IsComplete => _isComplete;

    // MarkComplete method: virtual, can be overridden
    public virtual void MarkComplete()
    {
        _isComplete = true;
    }

    // SetProgress method: virtual, to be overridden by classes that track progress
    public virtual void SetProgress(int timesCompleted, bool isComplete)
    {
        // Default does nothing - overridden in derived classes that track progress
    }

    public virtual string GetDetailsString()
    {
        return $"{_name} ({_description}) - Points: {_points} - Completed: {_isComplete}";
    }

    // Abstract method to record an event, forces derived classes to implement
    public abstract void RecordEvent();

    // You may want a method to display the goal status
    public virtual void Display()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_name} ({_description})");
    }
}
