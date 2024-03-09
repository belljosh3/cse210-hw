using System;

class Program
{
    static void Main(string[] args)
    {
        //loop to keep asking what the user wants to do
        //displays 5 options: write, display, load, save, quit
        Journal journal = new Journal();
        Entry newEntry = new Entry();
        PromptsGenerator prompt = new PromptsGenerator();
        int selection;
        do {
            Console.WriteLine("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            selection = int.Parse(Console.ReadLine());
            if (selection == 1)
            {   
                newEntry._promptText = prompt.RandomPrompt();
                Console.WriteLine($"{newEntry._promptText}");
                Console.Write("> ");
                newEntry._entryText = Console.ReadLine();
                newEntry._date = DateTime.Now;
                journal.AddEntry(newEntry);
            }
            else if (selection == 2)
            {
                journal.DisplayEntries();
            }
            else if (selection == 3)
            {   
                Console.WriteLine("What is the filename?");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            else if (selection == 4)
            {
                Console.WriteLine("What is the filename?");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }
        } while (selection != 5); 
    }
}