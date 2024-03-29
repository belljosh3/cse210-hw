using System.Formats.Asn1;
using System.Runtime.CompilerServices;

public class GoalManager
{
    private List<Goal> _goals;
    protected int _score;

    private int _level;
    private string _title;




    public GoalManager()
    {
        //Initializes the empty list of goals and sets the player's score to 0.
        _goals = new List<Goal>();
        _score = 0;
        _level = 0;
        SetTitle();
    }

    public void Start()
    {
        //This is "main" function for this class. It is called by Program.cs, and then runs the menu loop.
        int choice;
        do{
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Progress\n  4. Load Progress\n  5. Record Event\n  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    CreateGoal();
                    break;
                } 
                case 2:
                {
                    ListGoalDetails();
                    Console.WriteLine("Press ENTER to go back to the Main Menu");
                    Console.ReadLine();
                    break;
                }
                case 3:
                {
                    SaveGoals();
                    break;
                }
                case 4:
                {
                    LoadGoals();
                    break;
                }
                case 5:
                {
                    RecordEvent();
                    break;
                }
                default:
                {
                    break;
                }
            }

            Console.Clear();

        } while (choice != 6);
    }
    public void DisplayPlayerInfo()
    {
        //Displays the players current score.
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"\nYour level is: {_level} - {_title}");
    }
    public void ListGoalNames()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"  {i + 1}. {goal.GetShortName()}");
        }
    }
    public void ListGoalDetails()
    {
        
        Console.Clear();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string goalDetails = $"{i + 1}. {goal.GetDetailsString()}";
            Console.WriteLine(goalDetails);
        }
    }
    public void CreateGoal()
    {
        Console.Clear();
        //Asks the user for the information about a new goal. Then, creates the goal and adds it to the list.
        Console.WriteLine("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string gName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string gDescription = Console.ReadLine();
        
        Console.WriteLine("\n---It is recommended for faster leveling to make point values of 200 or more---");
        Console.Write("What is the amount of points associated with this goal? ");
        string gPoints = Console.ReadLine();

        switch (goalType)
        {
            case 1:
                _goals.Add(new SimpleGoal(gName, gDescription, gPoints));
                break;
            case 2:
                _goals.Add(new EternalGoal(gName, gDescription, gPoints));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int gTarget = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int gBonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(gName, gDescription, gPoints, gTarget, gBonus));
                break;
            default:
                break;
        }
    }
    public void RecordEvent()
    {
        //Asks the user which goal they have done and then records the event by calling the RecordEvent method on that goal.
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int cGoal = int.Parse(Console.ReadLine()) - 1;

        _goals[cGoal].RecordEvent();
        
        _score += _goals[cGoal].GetPoints();
        
        Console.WriteLine($"You now have {_score} points.");
        
        DisplayLevel();

        ShowDots(5);
    }
    public void SaveGoals()
    {
        //Saves the list of goals to a file.
        using (StreamWriter outputFile = new StreamWriter("goals.txt", false))
        {
            outputFile.WriteLine($"{_score}");
            outputFile.WriteLine($"{_level}");
            outputFile.WriteLine($"{_title}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetType().Name}:{goal.GetStringRepresentation()}");
            }
        }
        Console.Write("Saving file");
        ShowDots(4);
    }
    public void LoadGoals()
    {
        //Loads the list of goals from a file.
        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _title = lines[2];

        foreach (string line in lines.Skip(3))
        {
            string[] typeParts = line.Split(':');
            string[] gParts = typeParts[1].Split('|');

            if (typeParts[0] == "SimpleGoal")
            {
                SimpleGoal simple = new SimpleGoal(gParts[0], gParts[1], gParts[2]);
                _goals.Add(simple);
                simple.SetIsComplete(gParts[3]);
            } else if (typeParts[0] == "EternalGoal")
            {
                _goals.Add(new EternalGoal(gParts[0], gParts[1], gParts[2]));
            }else if (typeParts[0] == "ChecklistGoal")
            {
                ChecklistGoal checklist = new ChecklistGoal(gParts[0], gParts[1], gParts[2], int.Parse(gParts[4]), int.Parse(gParts[3]));
                _goals.Add(checklist);
                checklist.SetAmountCompleted(int.Parse(gParts[5]));
                checklist.IsComplete();
            }
        }
        
        Console.Write("Loading file");
        ShowDots(4);

    }

    public void ShowDots(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }

    private bool SetLevel(int score)
    {
        int lNum = score / 500;

        if (_level >= lNum)
        {
            return false;
        } else {
            _level = lNum;
            return true;
        }
    }

    private void SetTitle()
    {
        List<string> adj = new List<string>{"Attractive", "Bald", "Beautiful", "Clean", "Drab", "Elegant", "Fit", "Gorgeous", "Handsome", "Magnificant", "Plain", "Unkempt", "Colossal", "Little", "Tiny", "Calm", "Faithful", "Kind", "Jolly", "Obedient", "Silly"};
        List<string> noun = new List<string>{"Vase", "Napkin", "Breakfast", "Teacher", "Painting", "Apple", "Notebook", "Spoon", "Beach", "Advertisement", "Yacht", "Rose", "Pencil", "Cartoon", "Bed", "Garden", "Umbrella", "Telephone", "Horse", "Magician", "Pizza"};

        //make random generators for lists
        Random randomNumber = new Random();
        int aNumber = randomNumber.Next(0,adj.Count());
        int nNumber = randomNumber.Next(0,noun.Count());

        _title = $"The {adj[aNumber]} {noun[nNumber]}";
    }

    public void DisplayLevel()
    {
        if (SetLevel(_score))
        {
            SetTitle();

            Console.WriteLine("\nCONGRATULATIONS!!!");
            Console.WriteLine($"Your new Level and Title are: {_level} - {_title}");
        } else {
            Console.WriteLine($"Your current level is: {_level} - {_title}");
        }
    }
}