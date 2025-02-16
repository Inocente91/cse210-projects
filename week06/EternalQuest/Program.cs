using System;
using System.Collections.Generic;
using System.IO;

// Base Goal class
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return $"{_name} ({_description})";
    }
    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_name},{_description},{_points}";
    }
}

// SimpleGoal class
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{_isComplete}";
    }

    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {base.GetDetailsString()}";
    }
}

// EternalGoal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {base.GetDetailsString()}";
    }
}

// ChecklistGoal class
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        int points = _points;
        if (_currentCount == _targetCount)
        {
            points += _bonusPoints;
        }
        return points;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"[{(_currentCount >= _targetCount ? "X" : " ")}] {base.GetDetailsString()} -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{_targetCount},{_bonusPoints},{_currentCount}";
    }
}

// NegativeGoal class
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return -_points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {base.GetDetailsString()} (Negative)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name},{_description},{_points}";
    }
}


// GoalManager class
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _highestScore;

    public int Score => _score;
    public int HighestScore => _highestScore;
    public int Level => _highestScore / 1000;
    public int NextLevelPoints => 1000 - (_highestScore % 1000);

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _highestScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");

            if (_score > _highestScore)
            {
                int previousHighest = _highestScore;
                _highestScore = _score;
                CheckLevelUp(previousHighest, _highestScore);
            }
        }
    }

    private void CheckLevelUp(int previous, int current)
    {
        int previousLevel = previous / 1000;
        int currentLevel = current / 1000;
        if (currentLevel > previousLevel)
        {
            int bonus = currentLevel * 100;
            _score += bonus;
            _highestScore = _score; // Update highest score again after bonus
            Console.WriteLine($"Congratulations! You've reached Level {currentLevel}!");
            Console.WriteLine($"You received a level bonus of {bonus} points!");
        }
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
        }
        Console.WriteLine($"Total Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_score},{_highestScore}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            string[] firstLine = lines[0].Split(',');
            _score = int.Parse(firstLine[0]);
            _highestScore = int.Parse(firstLine[1]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
