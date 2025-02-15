using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected static List<ActivityLog> _logs = new List<ActivityLog>();

        public class ActivityLog
        {
            public string Name { get; set; }
            public int Duration { get; set; }
            public DateTime Date { get; set; }
        }

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public static List<ActivityLog> GetLogs()
        {
            return _logs;
        }

        public abstract void Run();

        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity.");
            Console.WriteLine(_description);
            Console.Write("Enter the duration in seconds: ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine("\nGood job!");
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            _logs.Add(new ActivityLog { Name = _name, Duration = _duration, Date = DateTime.Now });
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            List<string> animation = new List<string> { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int index = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(animation[index]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                index = (index + 1) % animation.Count;
            }
            Console.WriteLine();
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }

    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            bool breatheIn = true;

            while (DateTime.Now < endTime)
            {
                if (breatheIn)
                {
                    Console.WriteLine("Breathe in...");
                    int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
                    int duration = Math.Min(3, remaining);
                    if (duration > 0)
                        ShowCountdown(duration);
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                    int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
                    int duration = Math.Min(2, remaining);
                    if (duration > 0)
                        ShowCountdown(duration);
                }
                breatheIn = !breatheIn;
            }

            DisplayEndingMessage();
        }
    }

    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private static Random _rnd = new Random();

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        private string GetRandomPrompt()
        {
            return _prompts[_rnd.Next(_prompts.Count)];
        }

        private string GetRandomQuestion()
        {
            return _questions[_rnd.Next(_questions.Count)];
        }

        public override void Run()
        {
            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine($"Consider the following prompt:\n--- {prompt} ---");
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountdown(5);

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.Write(question + " ");
                int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
                int spinnerTime = Math.Min(5, remaining);
                if (spinnerTime <= 0)
                    break;
                ShowSpinner(spinnerTime);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }

    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private static Random _rnd = new Random();

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        private string GetRandomPrompt()
        {
            return _prompts[_rnd.Next(_prompts.Count)];
        }

        public override void Run()
        {
            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine($"List as many things as you can about: {prompt}");
            Console.Write("You may begin in: ");
            ShowCountdown(5);

            Console.WriteLine("Start listing...");
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            int itemCount = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    itemCount++;
                }
            }

            Console.WriteLine($"You listed {itemCount} items.");
            DisplayEndingMessage();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Activity Log");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        ViewLog();
                        continue;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Thread.Sleep(2000);
                        continue;
                }

                activity.Run();
            }
        }

        static void ViewLog()
        {
            Console.Clear();
            var logs = Activity.GetLogs();
            if (logs.Count == 0)
            {
                Console.WriteLine("No activities logged yet.");
            }
            else
            {
                Console.WriteLine("Activity Log:");
                foreach (var log in logs)
                {
                    Console.WriteLine($"{log.Date:yyyy-MM-dd HH:mm:ss} - {log.Name} ({log.Duration} seconds)");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}

// Exceeding Requirements:
// - Added activity logging that tracks each completed activity with duration and timestamp.
// - Users can view the log via the main menu to see their mindfulness exercise history.