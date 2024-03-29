using System.Dynamic;

public class SimpleGoal : Goal
{
    bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        //This should also set the variables for if it is complete to be false;
        _isComplete = false;

    }

    public override void RecordEvent()
    {
        _isComplete = true;

        Console.WriteLine($"Congradulations! You have earned an additional {_points} points!");
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public void SetIsComplete(string complete)
    {
        _isComplete = bool.Parse(complete);
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName}|{_description}|{_points}|{_isComplete}";
        
    }
}