class Listing : Activity
{
    List<string> prompts = new List<string>
    {
        "People you like",
        "Your strengths",
        "People you helped"
    };

    public Listing()
    {
        activityName = "Listing";
        description = "List good things in your life!";
    }

    public void Start()
    {
        BasicStartMessage();

        Random rand = new Random();
        Console.WriteLine("List items about: " + prompts[rand.Next(prompts.Count)]);
        Console.WriteLine("Starting in...");
        CountTimer(5);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(timeDuration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items!");
        BasicEndMessage();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                new Breathing().Start();
            }
            else if (choice == "2")
            {
                new Reflection().Start();
            }
            else if (choice == "3")
            {
                new Listing().Start();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice!");
                Thread.Sleep(1000);
            }
        }
    }
}
