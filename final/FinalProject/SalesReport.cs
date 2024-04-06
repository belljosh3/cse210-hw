public class SalesReport 
{
    protected double profit;
    protected string date;

    public virtual void DisplayReport(RegisterManager registers, TargetData target)
    {
        registers.CalculateTotal();
        profit = registers.GetTotal() - target.GetTarget();
        date = DateTime.Today.ToString("MM-dd-yyyy");

        Console.Clear();
        Console.WriteLine($"{date}");
        Console.WriteLine($"\nProfit: ${profit}");
        Console.WriteLine($"Target: ${target.GetTarget()}");

        Console.WriteLine($"\n{registers.Count()} registers brought in ${registers.GetTotal()} total.");
    }
}