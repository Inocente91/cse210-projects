class Breathing : Activity
{
    public Breathing()
    {
        activityName = "Breathing";
        description = "This helps you relax by breathing slowly. Focus on your breath.";
    }

    public void Start()
    {
        BasicStartMessage();

        int cycles = timeDuration / 5;  // Each cycle is 5 seconds
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            CountTimer(3);
            Console.WriteLine("Breathe out...");
            CountTimer(2);
        }

        BasicEndMessage();
    }
}
