using System;

public class Entry {
    public DateTime _date;
    public string _promptText;
    public string _entryText;

    public Entry() {
        PromptsGenerator generator = new PromptsGenerator();
        _promptText = generator.RandomPrompt();
    }
}