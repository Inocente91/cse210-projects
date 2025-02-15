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
}
