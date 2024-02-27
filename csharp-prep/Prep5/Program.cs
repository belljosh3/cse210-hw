using System;

class Program
{
    static void Main(string[] args)
    {
        
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int bigNumber = SquareNumber(number);
        DisplayResult(name, bigNumber);
    }
       static void DisplayWelcome ()
       {
            Console.WriteLine("Welcome to the Program!");
       }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber ()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquareNumber (int num1)
        {   
            int sqNum = num1 * num1;
            return sqNum;
        }

        static void DisplayResult (string inputName, int squaredNumber)
        {
            Console.WriteLine($"{inputName}, the square of your number is {squaredNumber}");
        }

}