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