using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class Activity
    {
        public string activityName;
        public string description;
        public int timeDuaration;


        public void BasicStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {activityName} Activity.");
            Console.WriteLine(description);
            Console.Write("How long do you want do this activity? (seconds); ");
            Console.WriteLine("Get Ready...");
            WaitSpinner(3);
        }
    }
}