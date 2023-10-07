using System;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public List<Entry> GetEntries()
    {
        return _entries;
    }
    public void SaveToFile()
    {
        Console.Write("What is the filename\n>");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
            {
            foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}~{entry._prompt}~{entry._response}");
                }
            }
        Console.WriteLine("File saved successfully.\n");
    }
    public void LoadFile()
    {
        Console.Write("What is the filename\n>");
        string fileName = Console.ReadLine();
        if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                _entries.Clear();

                foreach (string line in lines)
                {
                    string[] parts = line.Split("~");

                    DateTime currentDateTime = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string response = parts[2];
                    
                    Entry newEntry = new Entry(currentDateTime, prompt, response);
                    _entries.Add(newEntry);
                }
                Console.WriteLine("Journal loaded successfully.\n");
            }
        else
            {
                Console.WriteLine("File not found.\n");
            }
    }
    
}


