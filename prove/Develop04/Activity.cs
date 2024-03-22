using System.Dynamic;
using Microsoft.VisualBasic;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"This activity will help you {_description}\n");
        Console.Write("How long in seconds, would you like your session? ");

        _duration = int.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("Get Ready...");
        ShowSpinner(10);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!\n");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");

        ShowSpinner(30);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {   
        List<string> animationString = new List<string>();
        animationString.Add("|");
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");
        animationString.Add("|");
        animationString.Add("/");
        animationString.Add("-");
        animationString.Add("\\");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (endTime > DateTime.Now)
        {
            string s = animationString[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;
            
            if (i >= animationString.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}