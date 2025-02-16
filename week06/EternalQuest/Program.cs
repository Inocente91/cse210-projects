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
