using System.Drawing;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _isComplete = false;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        //In addition to the standard attributes, a checklist goal also needs the target and bonus amounts. Then, it should set the amount completed to begin at 0.
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (IsComplete())
        {
            int tPoints = int.Parse(_points) + _bonus;
            Console.WriteLine($"Congratulations! You have earned {tPoints} points!");
        } else {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
        }
    }

    public override int GetPoints()
    {
        if (_isComplete)
        {
            return int.Parse(_points) + _bonus;
        } else {
            return int.Parse(_points);
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            _isComplete = true;
        } else {
            _isComplete = false;
        }
        return _isComplete;
    }
    public override string GetDetailsString()
    {
                string checkbox;

        if (IsComplete())
        {
            checkbox = "[X]";    
        } else {
            checkbox = "[ ]";
        }

        return $"{checkbox} {_shortName} ({_description})  --- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }

    public void SetAmountCompleted(int completed)
    {
        _amountCompleted = completed;
    }
}