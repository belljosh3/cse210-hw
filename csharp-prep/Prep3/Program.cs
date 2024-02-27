using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Magic Number Guessing Game");
        int guessNumber;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,100);

        do
        {
            Console.WriteLine("");
            Console.Write("Enter your guess: ");
            string guessValue = Console.ReadLine();
            guessNumber = int.Parse(guessValue);

            if (guessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guessNumber != magicNumber);
    }
}