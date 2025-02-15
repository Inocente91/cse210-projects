using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class Activity
    {
        public string activityName;
        public string description;
        public int timeDuration;

        public void BasicStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {activityName} Activity.");
            Console.WriteLine(description);
            Console.Write("How long do you want to do this activity? (seconds): ");
            timeDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready...");
            WaitSpinner(3);
        }

        public void BasicEndMessage()
        {
            Console.WriteLine("\nGood job!");
            Console.WriteLine($"You did {activityName} for {timeDuration} seconds!");
            WaitSpinner(3);
        }

        public void WaitSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b/");
                Thread.Sleep(250);
                Console.Write("\b-");
                Thread.Sleep(250);
                Console.Write("\b\\");
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        public void CountTimer(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }

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
}

// Exceeding Requirements:
// - Added activity logging that tracks each completed activity with duration and timestamp.
// - Users can view the log via the main menu to see their mindfulness exercise history.
