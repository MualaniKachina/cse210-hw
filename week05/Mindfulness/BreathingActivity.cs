public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        int interval = 6;
        int cycles = _duration / interval;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in...");
            AnimationHelper.Countdown(3);
            Console.Write("Breathe out...");
            AnimationHelper.Countdown(3);
        }

        DisplayEndingMessage();
    }
}
