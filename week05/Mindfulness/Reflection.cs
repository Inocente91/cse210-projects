class Reflection : Activity
{
    List<string> prompts = new List<string>
    {
        "Think of a time you helped someone",
        "Think of a hard thing you did",
        "Think of when you were kind"
    };

    List<string> questions = new List<string>
    {
        "Why was this good?",
        "How did you start?",
        "How did you feel after?"
    };

    public Reflection()
    {
        activityName = "Reflection";
        description = "Think about times you were strong. This helps you see your power!";
    }

    public void Start()
    {
        BasicStartMessage();

        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Console.WriteLine("Press Enter when ready");
        Console.ReadLine();

        Console.WriteLine("Answer these questions:");
        CountTimer(5);

        DateTime endTime = DateTime.Now.AddSeconds(timeDuration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            WaitSpinner(5);
        }

        BasicEndMessage();
    }
}
