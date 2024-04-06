public class TargetData
{
    private double _target;

    public void SetTarget()
    {
        Console.Write("Enter the total sales goal for the day (in USD): ");
        double target = double.Parse(Console.ReadLine());
        _target = target;
    }

    public double GetTarget()
    {
        return _target;
    }

}