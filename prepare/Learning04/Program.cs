using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine($"{assignment.GetSummary()}");

        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Factions", "7.3", "8-19");
        Console.WriteLine($"{math.GetSummary()}");
        Console.WriteLine($"{math.GetHomeworkList()}");

        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The Cause of World War II");
        Console.WriteLine($"{writing.GetSummary()}\n{writing.GetWritingInformation()}");
    }
}