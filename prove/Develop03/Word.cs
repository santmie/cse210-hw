using System;

public class Word
{
    private string _text;
    private bool _hidden;

    public string GetText() //returns the value of the _text
    {
        return _text;
    }

    private void SetText(string text) //assign a new value to the _text
    {
        _text = text; //sets the value of the _text variable to whatever string is passed to text parameter
    }

    public bool GetHidden() //returns the value of the _hidden
    {
        return _hidden;
    }

    private void SetHidden(bool hidden) //assign a new value to the _hidden
    {
        _hidden = hidden; //sets the value of the _hidden variable based on the provided boolean hidden parameter
    }

    public Word(string text) //constructor for the Word class
    {
        SetText(text); //set the text using the SetText method.
        SetHidden(false); //sets the value of the private _hidden to false - the word is not hidden
    }

    public void Hide() //method to set the _hidden field to true
    {
        SetHidden(true); 
    }

    public void Show() //method that sets the _hidden field to false - the word is not hidden
    {
        SetHidden(false);
    }
    
    public override string ToString() //override of the ToString method.
    {
        if (GetHidden()) // check if the word is hidden
        {
            return new string('_', GetText().Length); //replace each character of the hidden word with an underscore
        }
        else
        {
            return GetText(); //return the text of the word if it's not hidden.
        }
    }
}
