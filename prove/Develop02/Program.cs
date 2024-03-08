using System;

class Program
{
    static void Main(string[] args)
    {
        //loop to keep asking what the user wants to do
        //displays 5 options: write, display, load, save, quit
        int selection;
        do {
            Console.WriteLine("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            selection = int.Parse(Console.ReadLine());
            if (selection == 1)
            {   
                Console.WriteLine($"{Entry._date}");
                // PromptsGenerator newPrompt = new PromptsGenerator();
                // newPrompt.DisplayPrompts();
            }
            else if (selection == 2)
            {

            }
            else if (selection == 3)
            {

            }
            else if (selection == 4)
            {

            }
        } while (selection != 5); 
    }
}