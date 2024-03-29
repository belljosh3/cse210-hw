using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("\nWelcome to the Eternal Quest\n");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}