public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"You earned {_points} points!");
        // Eternal goals never mark complete
    }

    public override void MarkComplete()
    {
        // Do nothing - eternal goals never complete
    }
}
