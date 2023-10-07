using System;
public class Entry
{
    public DateTime _date;
    public string _prompt;
    public string _response;
    public Entry (DateTime currentDateTime, string prompt, string response)
    {
        _date = currentDateTime;
        _prompt = prompt;
        _response = response;
    }
    public void DisplayEntry()
    {
        string shortDate = _date.ToShortDateString();
        Console.WriteLine($"Date: {shortDate} - Prompt: {_prompt}");
        Console.WriteLine($"{_response}");
        Console.WriteLine();
    }
}