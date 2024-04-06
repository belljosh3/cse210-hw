public class DetailedReport : SalesReport
{
    public override void DisplayReport(RegisterManager registers, TargetData target)
    {
        base.DisplayReport(registers, target);

        Console.WriteLine("\nBreakdown of each Register:");
        int regNum = 0;
        foreach (Register register in registers.GetRegisters())
        {
            regNum++;
            Console.WriteLine($"Register#{regNum} - Hundreds: {register.GetHundreds()}, Fifties: {register.GetFifties()}, Twenties: {register.GetTwenties()}, Tens: {register.GetTens()}, Fives: {register.GetFives()}, Ones: {register.GetOnes()}, Quarters: {register.GetQuarters()}, Dimes: {register.GetDimes()}, Nickels: {register.GetNickels()}, Pennies: {register.GetPennies()}");
        }
    }
}