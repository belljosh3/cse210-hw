using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<float> enteredNumbers = new List<float>();
        float number;

        //ask for numbers to be added to list
        do 
        {
            Console.Write("Enter Number: ");
            string newNumber = Console.ReadLine();
            number = float.Parse(newNumber);

            if (number != 0)
            {
                enteredNumbers.Add(number);
            }
        } while (number != 0);

        //calculate the sum
        float sum = 0;
        foreach (int num in enteredNumbers)
        {
            sum += num;
        }

        Console.WriteLine($"The sum is: {sum}");

        //calculate the average
        float average = sum / enteredNumbers.Count;
        Console.WriteLine($"The average is: {average}");
    
        //find max
        float max = 0;
        for (int i = 0; i < enteredNumbers.Count; i++)
        {
            if (enteredNumbers[i] > max)
            {
                max = enteredNumbers[i];
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}