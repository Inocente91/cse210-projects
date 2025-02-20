using System;
using System.Collections.Generic;

namespace ExerciseTracker
{
    // Base class for all activities
    public abstract class Activity
    {
        private DateTime _date; // Date of the activity
        private int _minutes;   // Duration in minutes

        // Constructor to set date and minutes
        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Properties to get date and minutes
        public DateTime Date => _date;
        public int Minutes => _minutes;

        // Abstract methods to calculate distance, speed, and pace
        public abstract double GetDistance(); // Distance in miles
        public abstract double GetSpeed();    // Speed in mph
        public abstract double GetPace();    // Pace in minutes per mile

        // Method to get a summary of the activity
        public virtual string GetSummary()
        {
            return $"{Date.ToShortDateString()} {GetType().Name} ({Minutes} min) - " +
                   $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
        }
    }

    // Class for Running activity
    public class Running : Activity
    {
        private double _distance; // Distance in miles

        // Constructor to set date, minutes, and distance
        public Running(DateTime date, int minutes, double distance)
            : base(date, minutes)
        {
            _distance = distance;
        }

        // Override methods for running
        public override double GetDistance() => _distance;
        public override double GetSpeed() => (_distance / Minutes) * 60;
        public override double GetPace() => Minutes / _distance;
    }

    // Class for Cycling activity
    public class Cycling : Activity
    {
        private double _speed; // Speed in mph

        // Constructor to set date, minutes, and speed
        public Cycling(DateTime date, int minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        // Override methods for cycling
        public override double GetDistance() => (_speed * Minutes) / 60;
        public override double GetSpeed() => _speed;
        public override double GetPace() => 60 / _speed;
    }

    // Class for Swimming activity
    public class Swimming : Activity
    {
        private int _laps; // Number of laps

        // Constructor to set date, minutes, and laps
        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        // Override methods for swimming
        public override double GetDistance() => _laps * 50 / 1000 * 0.62; // Convert laps to miles
        public override double GetSpeed() => (GetDistance() / Minutes) * 60;
        public override double GetPace() => Minutes / GetDistance();
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold activities
            var activities = new List<Activity>();

            // Add some activities to the list
            activities.Add(new Running(new DateTime(2023, 10, 1), 30, 3.0)); // Running activity
            activities.Add(new Cycling(new DateTime(2023, 10, 2), 45, 15.0)); // Cycling activity
            activities.Add(new Swimming(new DateTime(2023, 10, 3), 20, 30)); // Swimming activity

            // Loop through the list and display summaries
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}