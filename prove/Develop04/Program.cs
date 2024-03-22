using System;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {   
        int choice;
        Log log = new Log();

        do {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity\n2. Start reflecting activity\n3. Start listing activity\n4. Today's log\n5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

        
            if (choice == 1)
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run(log);
            } else if (choice == 2)
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run(log);
            } else if (choice == 3)
            {
                ListingActivity listing = new ListingActivity();
                listing.Run(log);
            } else if (choice == 4)
            {
                //show how many times each activity has been done since the program started and total time spent on each activity.
                log.DisplayLog();
            }
            
        } while (choice != 5);
    }
}