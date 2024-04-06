using System.Dynamic;

public class MissedSalesReport : SalesReport
{
    private string _date;

    public void SetDate(string dateString)
    {
        _date = dateString;
    }

    public override void DisplayReport(RegisterManager registers, TargetData target)
    {
        registers.CalculateTotal();
        profit = registers.GetTotal() - target.GetTarget();

        Console.Clear();
        Console.WriteLine($"{_date}");
        Console.WriteLine($"\nProfit: ${profit}");
        Console.WriteLine($"Target: ${target.GetTarget()}");

        Console.WriteLine($"\n{registers.Count()} registers brought in ${registers.GetTotal()} total.");

        Console.WriteLine("\nBreakdown of each Register:");
        int regNum = 0;
        foreach (Register register in registers.GetRegisters())
        {
            regNum++;
            Console.WriteLine($"Register#{regNum} - Hundreds: {register.GetHundreds()}, Fifties: {register.GetFifties()}, Twenties: {register.GetTwenties()}, Tens: {register.GetTens()}, Fives: {register.GetFives()}, Ones: {register.GetOnes()}, Quarters: {register.GetQuarters()}, Dimes: {register.GetDimes()}, Nickels: {register.GetNickels()}, Pennies: {register.GetPennies()}");
        }
    }
}