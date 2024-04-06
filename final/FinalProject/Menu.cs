using System.Linq.Expressions;
using System.Net.Http.Headers;

public class Menu
{
    public Menu()
    {
        
    }

    public void Start()
    {
        RegisterManager registers = new RegisterManager();
        TargetData target = new TargetData();
        SalesReport report = new SalesReport();
        DetailedReport detailed = new DetailedReport();
        MissedSalesReport missed = new MissedSalesReport();
        SaveReport save = new SaveReport();

        int choice = 0;

        do {
            Console.Clear();
            Console.WriteLine("Please select from the following:\n 1. Input Registers\n 2. View Report\n 3. Save Report\n 4. Quit");
            Console.Write(">> ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    Console.Clear();
                    Console.WriteLine("Is this data for:\n 1. Today\n 2. Missed day");
                    Console.Write(">> ");
                    int dChoice = int.Parse(Console.ReadLine());
                    if (dChoice == 1)
                    {
                        Console.Clear();
                        //call on registers class to add to register manager list
                        string another = "yes";

                        target.SetTarget();

                        while (another != "no")
                        {
                            Register register = new Register();
                            registers.AddRegister(register);
                            Console.Clear();
                            Console.Write("Would you like to add another (yes/no)? ");
                            another = Console.ReadLine();
                        }
                    } else if (dChoice == 2)
                    {
                        Console.Clear();
                        Console.Write("Please enter the date of the missed report (MM-DD-YYYY): ");
                        string dateString = Console.ReadLine();
                        
                        
                        missed.SetDate(dateString);
                        target.SetTarget();

                        string another = "yes";
                        while (another != "no")
                        {
                            Register register = new Register();
                            registers.AddRegister(register);
                            Console.Clear();
                            Console.Write("Would you like to add another (yes/no)? ");
                            another = Console.ReadLine();
                        }

                        Console.Write("Automatically Generating report");
                        ShowDots(5);
                        missed.DisplayReport(registers, target);
                        
                        Console.WriteLine("\n\nWould you like to save this report (yes/no)? ");
                        string saveReport = Console.ReadLine();

                        if (saveReport == "yes")
                        {
                            Console.Write($"Saving the report for {dateString}");
                            ShowDots(10);
                            save.SaveReportFile(dateString, registers.GetTotal(), target.GetTarget(), registers.GetRegisters());
                        }
                    }

                    break;
                }
                case 2:
                {
                    Console.Clear();
                    Console.WriteLine("Please select one of the following:\n 1. Current day's report\n 2. Previous report");
                    Console.Write(">> ");
                    int rChoice = int.Parse(Console.ReadLine());
                    
                    if (rChoice == 1)
                    {
                        report.DisplayReport(registers, target);
                            //delay 10s
                            ShowDots(10);
                        
                        Console.Write("\n\nWould you like to see a detailed report of this (yes/no)? ");
                        string dChoice = Console.ReadLine();
                        
                        if (dChoice == "yes")
                        {
                            detailed.DisplayReport(registers, target);
                            Console.WriteLine("\nPress ENTER to go back to the Main Menu.");
                            Console.ReadLine();
                        }

                    } else if (rChoice == 2)
                    {
                        Console.Write("Enter the date of the report you want to view (MM-DD-YYYY): ");
                        string date = Console.ReadLine();
                        save.LoadReportFile(date);
                    }
                    break;

                }
                case 3:
                {

                    Console.Clear();
                    Console.Write("Saving today's report");
                    ShowDots(10);

                    string date = DateTime.Today.ToString("MM-dd-yyyy");
                    save.SaveReportFile(date, registers.GetTotal(), target.GetTarget(), registers.GetRegisters());
                    
                    break;
                }
            }
        } while (choice != 4);    
    }
    private void ShowDots(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }
}
