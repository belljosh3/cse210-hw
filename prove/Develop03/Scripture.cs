

public class Scripture{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(){
        //empty constructor for the save and load methods
    }
    public Scripture(Reference reference, string text){
        _reference = reference;
                
        string[] words = text.Split(' ');
        foreach (string word in words){
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide){
        Random randomNumber = new Random();
        for (int i = 0; i < numberToHide; i++){
            int index = randomNumber.Next(_words.Count);
            _words[index].Hide();
        }
    }
    public string GetDisplayText(){
        string display = $"{_reference.GetDisplayText()} ";
        foreach (Word word in _words){
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    public bool IsCompletelyHidden(){
        foreach (Word word in _words){
            if (!word.IsHidden()){
                return false;
            }
        }
        return true;
    }
    public void SaveToFile(Reference reference, string text, string fileName = "Scripture.txt"){
        using (StreamWriter outputFile = new StreamWriter(fileName, false)){      
                outputFile.WriteLine($"{reference.GetSaveText()}|{text}");
        }
    }

    public string[] LoadFromFile(string fileName = "Scripture.txt"){
        string line = System.IO.File.ReadAllText(fileName);
        string[] linePart = line.Split("|");
        return linePart;
    }
}