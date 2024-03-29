public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }
    public virtual int GetPoints()
    {
        return int.Parse(_points);
    }
    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox;

        if (IsComplete())
        {
            checkbox = "[X]";    
        } else {
            checkbox = "[ ]";
        }

        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}