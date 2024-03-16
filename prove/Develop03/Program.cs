using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture memorizer.\n");
        
        int choice = 0;
        string again;
        Reference reference = null;
        string text = null;

        while (choice != 1 && choice != 2 && choice != 3 && choice != 4){
            Console.Clear();
            Console.WriteLine("Which Scripture would you like to work on?\n1. John 3:16\n2. Proverbs 3:5-6\n3. New Custom Scripture\n4. Load Previous Custom Scripture");
            Console.Write("> ");
            choice = int.Parse(Console.ReadLine());
        }

        if (choice == 1){
            reference = new Reference("John", 3, 16);
            text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        } else if (choice == 2){
            reference = new Reference("Proverbs", 3, 5, 6);
            text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        } else if (choice == 3){
            Console.Clear();
            Console.Write("Enter book: ");
            string book = Console.ReadLine();
            book = char.ToUpper(book[0]) + book.Substring(1);
            Console.Write("Enter chapter: ");
            int chapter = int.Parse(Console.ReadLine());
            Console.Write("Enter verse: ");
            int verse = int.Parse(Console.ReadLine());
            Console.Write("Enter ending verse (if single verse LEAVE BLANK): ");
            string ending = Console.ReadLine();
            Console.WriteLine("Enter the text of the scripture(s)");
            Console.Write("> ");
            text = Console.ReadLine();
            if (string.IsNullOrEmpty(ending)){
                reference = new Reference(book, chapter, verse);
            } else {
                int end = int.Parse(ending);
                reference = new Reference(book, chapter, verse, end);
            }
            Scripture saveFile = new Scripture();
            saveFile.SaveToFile(reference, text);
        } else if (choice == 4){
            Scripture loadFile = new Scripture();
            string[] line = loadFile.LoadFromFile();
            if (line.Length == 4){
                reference = new Reference(line[0], int.Parse(line[1]), int.Parse(line[2]));
                text = line[3];
            } else{
                reference = new Reference(line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
                text = line[4];
            }
        }

        Scripture scripture = new Scripture(reference, text);

        do {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            scripture.HideRandomWords(3);

            
            bool hid = scripture.IsCompletelyHidden();
            if (hid){
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                again = "quit";
            }
            else {
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
                again = Console.ReadLine();
            }
        } while (again != "quit");
    }   
}