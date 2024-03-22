public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run(Log log)
    {
        DisplayStartingMessage();

        DisplayPrompt();

        DisplayQuestions();

        DisplayEndingMessage();

        log.GetLog(_name, _duration);
    }
    private string GetRandomPrompt()
    {
        Random randomNumber = new Random();
        int promptNumber = randomNumber.Next(0,_prompts.Count);
        
        return _prompts[promptNumber];
    }
    private string GetRandomQuestion()
    {
          
        Random randomNumber = new Random();
        int questionNumber = randomNumber.Next(0,_questions.Count());
        
        return _questions[questionNumber];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press ENTER to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.\n");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (endTime > DateTime.Now)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(15);
            Console.WriteLine("");
        }
    }
}