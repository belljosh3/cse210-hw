public class Job {
    //responsibilities: keeps track of company, job title, start year, end year
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;
        
    //behaviors: displays information in format "Job Title (company) StartYear-EndYear"
    public void DisplayJobDetails () {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
