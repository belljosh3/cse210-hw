using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class PromptsGenerator {
    public List<string> _prompts = new List<string>();

    public PromptsGenerator() {
    _prompts.Add("What was the best part of my day?");
    _prompts.Add("What was the best thing you ate today?");
    _prompts.Add("What is one thing if you could over today, you would do differently?");
    _prompts.Add("What are you grateful for today?");
    _prompts.Add("What was the most surprising thing that happend today?");

    }

    //randomly generate a number to display a different prompt
    public string RandomPrompt(){
        Random randomNumber = new Random();
        int promptNumber = randomNumber.Next(0,_prompts.Count);
        
        return _prompts[promptNumber];
    }
}