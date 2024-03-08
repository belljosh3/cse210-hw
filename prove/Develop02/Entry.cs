using System;

public class Entry {
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry() {
        DateTime currentDate = DateTime.Now;
        _date = currentDate.ToString("dd/MM/yyyy");

        PromptsGenerator generator = new PromptsGenerator();
        _promptText = generator.RandomPrompt();
    }
}