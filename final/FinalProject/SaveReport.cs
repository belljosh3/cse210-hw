public class SaveReport 
{
    public void SaveReportFile(string date, double total, double target, List<Register> registers)
    {
        using (StreamWriter outputFile = new StreamWriter($"{date}-SalesReport.txt", false))
        {
            outputFile.WriteLine($"Date: {date}");
            outputFile.WriteLine($"Total: {total}");
            outputFile.WriteLine($"Target: {target}");

            foreach (Register register in registers)
            {
                outputFile.WriteLine($"Hundreds: {register.GetHundreds()}, Fifties: {register.GetFifties()}, Twenties: {register.GetTwenties()}, Tens: {register.GetTens()}, Fives: {register.GetFives()}, Ones: {register.GetOnes()}, Quarters: {register.GetQuarters()}, Dimes: {register.GetDimes()}, Nickels: {register.GetNickels()}, Pennies: {register.GetPennies()}");
            }
        }
        
        Console.WriteLine($"\nReport Saved \"{date}-SalesReport.txt\"");
    }

    public void LoadReportFile(string date)
    {
        string[] lines = File.ReadAllLines($"{date}-SalesReport.txt");
        
        Console.Clear();
        string dateLine = lines[0];
        string dateNum = dateLine.Split(":")[1].Trim();
        Console.WriteLine($"{dateNum}");
        
        string totalLine = lines[1];
        double totalNum = double.Parse(totalLine.Split(":")[1].Trim());

        string targetLine = lines[2];
        double target = double.Parse(targetLine.Split(":")[1].Trim());
        double profit = totalNum - target;
        Console.WriteLine($"\nProfit: ${profit}");
        Console.WriteLine($"Target: ${target}");

        int regNum = 0;
        foreach (string line in lines.Skip(3))
        {
            regNum++;
            Console.WriteLine(line);
        }
        Console.WriteLine($"\n{regNum} registers brought in ${totalNum} total.");

    }
}