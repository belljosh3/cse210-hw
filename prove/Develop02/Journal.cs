using System;
using System.Collections.Generic;

public class Journal{
   public List<string> _entries = new List<string>(); 

  public void AddEntry(Entry newEntry) {
      string formattedEntry = $"{newEntry._date.ToString("M/d/yyyy")} - {newEntry._promptText} {newEntry._entryText}";
      _entries.Add(formattedEntry);
   }  

   public void DisplayEntries(){
      foreach (string entry in _entries){
         Console.WriteLine(entry);
      }
   }
}
