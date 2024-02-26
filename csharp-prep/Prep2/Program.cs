using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string getValue = Console.ReadLine();
        int grade = int.Parse(getValue);
        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80 && grade <= 89)
        {
            letter = "B";
        }
        else if (grade >= 70 && grade <= 79)
        {
            letter = "C";
        }
        else if (grade >= 60 && grade <=69)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congradulations! You Passed!!");
        }
        else 
        {
            Console.WriteLine("You did not pass, please take the class again.");
        }

    }
}