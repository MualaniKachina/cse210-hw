public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you feel afterward?",
        "How could this apply in other situations?",
        "What is your favorite thing about this experience?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();

        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        AnimationHelper.ShowSpinner(4);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("\n> " + question);
            AnimationHelper.ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}
