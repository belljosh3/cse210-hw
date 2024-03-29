public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congradulations! You have earned an additional {_points} points!");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName}|{_description}|{_points}";
    }
}