public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _timesRequired;
    private int _bonusPoints;

    public int TimesCompleted => _timesCompleted;
    public int TimesRequired => _timesRequired;
    public int BonusPoints => _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int timesRequired, int bonusPoints)
        : base(name, description, points)
    {
        _timesRequired = timesRequired;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"You earned {_points} points!");

        if (_timesCompleted >= _timesRequired)
        {
            MarkComplete();
            Console.WriteLine($"You earned a bonus of {_bonusPoints} points!");
        }
    }

    public override void MarkComplete()
    {
        _isComplete = true;
    }

    public override void SetProgress(int timesCompleted, bool isComplete)
    {
        _timesCompleted = timesCompleted;
        _isComplete = isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_name} ({_description}) - Completed {_timesCompleted}/{_timesRequired} times - Completed: {_isComplete}";
    }

    public override void Display()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_name} ({_description}) -- Completed {_timesCompleted}/{_timesRequired} times");
    }
}
