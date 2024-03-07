public class Resume {
    //responsibilities: keeps track of person's name and a list of their jobs
    public string _name;
    public List<Job> _jobs = new List<Job>();
    //behaviors: displays the resume, which shows name, followed by each one of the jobs
    public void DisplayResume() {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs) {
            job.DisplayJobDetails();
        }
    }
}