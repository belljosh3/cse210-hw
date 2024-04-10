using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Mail;

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
            Console.WriteLine("Please select from the following:\n 1. Input Registers\n 2. View Report\n 3. Quit");
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
                        
                        target.SetTarget();
                        registers.RegisterAddLoop();

                        Console.Clear();
                        Console.Write("Generating Report");
                        ShowDots(4);

                        report.DisplayReport(registers, target);
                        //delay 7s
                        ShowDots(7);
                        
                        Console.Write("\n\nWould you like to see a detailed report of this (yes/no)? ");
                        string detailChoice = Console.ReadLine();
                        
                        if (detailChoice == "yes")
                        {
                            detailed.DisplayReport(registers, target);
                        }

                        Console.Clear();
                        Console.Write("Saving today's report");
                        ShowDots(10);

                        string date = DateTime.Today.ToString("MM-dd-yyyy");
                        save.SaveReportFile(date, registers.GetTotal(), target.GetTarget(), registers.GetRegisters());

                    } else if (dChoice == 2)
                    {
                        Console.Clear();
                        registers.Reset();
                        Console.Write("Please enter the date of the missed report (MM-DD-YYYY): ");
                        string dateString = Console.ReadLine();
                        
                        missed.SetDate(dateString);
                        target.SetTarget();

                        registers.RegisterAddLoop();

                        Console.Clear();
                        Console.Write("Automatically Generating report");
                        ShowDots(5);
                        missed.DisplayReport(registers, target);
                        
                        Console.Write("\n\nWould you like to save this report (yes/no)? ");
                        string saveReport = Console.ReadLine();

                        if (saveReport == "yes")
                        {
                            Console.Clear();
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
                    Console.WriteLine("Please select one of the following:\n 1. Current day's report\n 2. Previously saved report");
                    Console.Write(">> ");
                    int rChoice = int.Parse(Console.ReadLine());
                    
                    if (rChoice == 1)
                    {   
                        string date = DateTime.Today.ToString("MM-dd-yyyy");
                        Console.Clear();
                        Console.Write("Generating Report");
                        ShowDots(7);
                        save.LoadReportFile(date);

                    } else if (rChoice == 2)
                    {
                        registers.Reset();
                        Console.Clear();
                        Console.Write("Enter the date of the report you want to view (MM-DD-YYYY): ");
                        string date = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Generating Report");
                        ShowDots(7);
                        save.LoadReportFile(date);
                    }
                    break;

                }
            }
        } while (choice != 3);    
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
