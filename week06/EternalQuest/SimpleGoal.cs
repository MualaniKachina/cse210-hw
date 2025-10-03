public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        MarkComplete();
        Console.WriteLine($"You earned {_points} points!");
    }
}
