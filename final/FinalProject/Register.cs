public class Register
{
    private int _pennies;
    private int _nickels;
    private int _dimes;
    private int _quarters;
    private int _ones;
    private int _fives;
    private int _tens;
    private int _twenties;
    private int _fifties;
    private int _hundreds;

    public Register()
    {
        Console.Clear();
        Console.Write("Please enter the number of PENNIES: ");
        _pennies = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of NICKLES: ");
        _nickels = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of DIMES: ");
        _dimes = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of QUARTERS: ");
        _quarters = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of ONES: ");
        _ones = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of FIVES: ");
        _fives = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of TENS: ");
        _tens = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of TWENTIES: ");
        _twenties = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of FIFTIES: ");
        _fifties = int.Parse(Console.ReadLine());
        Console.Write("Please enter the number of HUNDREDS: ");
        _hundreds = int.Parse(Console.ReadLine());
    }

    public int GetPennies()
    {
        return _pennies;
    }
    public int GetNickels()
    {
        return _nickels;
    }
    public int GetDimes()
    {
        return _dimes;
    }
    public int GetQuarters()
    {
        return _quarters;
    }
    public int GetOnes()
    {
        return _ones;
    }
    public int GetFives()
    {
        return _fives;
    }
    public int GetTens()
    {
        return _tens;
    }
    public int GetTwenties()
    {
        return _twenties;
    }
    public int GetFifties()
    {
        return _fifties;
    }
    public int GetHundreds()
    {
        return _hundreds;
    }
}