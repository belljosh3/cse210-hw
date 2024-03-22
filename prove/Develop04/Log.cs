public class Log
{
    private int _breathingTimes;
    private int _totalBreathing;
    private int _listingTimes;
    private int _totalListing;
    private int _reflectingTimes;
    private int _totalReflecting;

    public Log()
    {

    }
    public void GetLog(string name, int duration)
    {
        if (name == "Breathing")
        {
            _breathingTimes++;
            _totalBreathing += duration;
        } else if (name == "Reflecting")
        {
            _reflectingTimes++;
            _totalReflecting += duration;
        } else if (name == "Listening")
        {
            _listingTimes++;
            _totalListing += duration;
        }
    }
    public void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine($"Breathing Activity has been done {_breathingTimes} times, totalling: {_totalBreathing} seconds");
        Console.WriteLine($"Reflecting Activity has been done {_reflectingTimes} times, totalling: {_totalReflecting} seconds");
        Console.WriteLine($"Listing Activity has been done {_listingTimes} times, totalling: {_totalListing} seconds");
        Console.WriteLine("\nPress ENTER to return to the Main Menu.");
        Console.ReadLine();
        Console.Clear();
    }
}