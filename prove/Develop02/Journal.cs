using System;
using System.Collections.Generic;
using System.IO;

public class Journal{
   public List<string> _entries = new List<string>(); 

  public void AddEntry(Entry newEntry) {
      string formattedEntry = $"{newEntry._date.ToString("M/d/yyyy")} - Prompt: {newEntry._promptText}\n{newEntry._entryText}\n\n";
      _entries.Add(formattedEntry);
   }  

   public void DisplayEntries(){
      foreach (string entry in _entries){
         Console.WriteLine(entry);
      }
   }

   public void SaveToFile(string name){
      string fileName = name;
      using (StreamWriter outputFile = new StreamWriter(fileName)){      
         foreach (string entry in _entries){
            outputFile.WriteLine($"{entry}");
         }
      }
   }

   public void LoadFromFile(string name){
      string fileName = name;
      string[] lines = System.IO.File.ReadAllLines(fileName);

      foreach (string line in lines){
         _entries.Add(line);
      }
   }
}
