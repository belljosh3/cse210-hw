public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    public ListingActivity()
    {   
        _name = "Listening";
        _description = "relfect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");

    }

    public void Run(Log log)
    {
        DisplayStartingMessage();

        GetRandomPrompt();

        GetListFromUser();

        DisplayEndingMessage();

        log.GetLog(_name, _duration);
    }

    private void GetRandomPrompt() 
    {
        Random randomNumber = new Random();
        int promptNumber = randomNumber.Next(0,_prompts.Count());
        
        Console.WriteLine("\nList as many responses you can to the following Prompt:");
        Console.WriteLine($"--- {_prompts[promptNumber]} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine("");
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (endTime > DateTime.Now)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }
        _count = responses.Count();

        Console.WriteLine($"You listed {_count} items!");
        return _prompts;
    }
}