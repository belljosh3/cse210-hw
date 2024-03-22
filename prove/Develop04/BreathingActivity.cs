public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
    public void Run(Log log)
    {           
        DisplayStartingMessage();

        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (endTime > DateTime.Now)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(5);
            Console.Write("\nBreathe out...");
            ShowCountDown(5);
            Console.WriteLine("");
        }    

        DisplayEndingMessage();

        log.GetLog(_name, _duration);

    }
}