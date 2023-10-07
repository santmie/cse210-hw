using System;

public class Prompt
//generate prompt for journal entry
{
    public Random _random = new Random();
    string[] _randomQuestions = {
    //Your list of prompts must contain at least five different prompts. 
    //Make sure to add your own prompts to the list, but the following are examples to help get you started:
       "Who was the most interesting person I interacted with today?",
       "What was the best part of my day?",
       "How did I see the hand of the Lord in my life today?",
       "What was the strongest emotion I felt today?",
       "If I had one thing I could do over today, what would it be?"
    };

    // Generate random indexes for questions
    public string GetRandomQuestion()
    {
        int index = _random.Next(_randomQuestions.Length);
        return _randomQuestions[index];
    }
}