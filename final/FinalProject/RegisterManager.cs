public class RegisterManager
{
    protected List<Register> _registers;
    protected double _total;

    public RegisterManager()
    {
        _registers = new List<Register>();
    }
    public void AddRegister(Register register)
    {
        _registers.Add(register);
        Console.WriteLine("\nRegister added");
    }

    public void CalculateTotal()
    {
        _total = 0;
        foreach (Register register in _registers)
        {
            _total += register.GetPennies() * 0.01;
            _total += register.GetNickels() * 0.05;
            _total += register.GetDimes() * 0.1;
            _total += register.GetQuarters() * 0.25;
            _total += register.GetOnes();
            _total += register.GetFives() * 5;
            _total += register.GetTens() * 10;
            _total += register.GetTwenties() * 20;
            _total += register.GetFifties() * 50;
            _total += register.GetHundreds() * 100;
        }
    }

    public double GetTotal()
    {
        return _total;
    }

    public void SetTotal(double total)
    {
        _total = total;
    }

    public int Count()
    {
        return _registers.Count;
    }

    public List<Register> GetRegisters()
    {
        return _registers;
    }
}