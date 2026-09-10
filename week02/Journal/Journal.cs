public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "What was the best part of my day?",
            "What did I learn today?",
            "Who did I help today?",
            "What is something I am grateful for?",
            "What would I like to improve tomorrow?",
            "What was the most interesting thing I experienced today?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);

        return prompts[index];
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Choose \"write\" to add an entry.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        // Each entry becomes one line: date~prompt~response.
        // "~" is the separator because it is not used in normal writing.
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~{entry._prompt}~{entry._response}");
            }
        }

        Console.WriteLine($"Saved {_entries.Count} entr{(_entries.Count == 1 ? "y" : "ies")} to \"{fileName}\".");
    }

    public void LoadFromFile(string fileName)
    {
        // CREATIVITY: loading a missing file gives a friendly message
        // instead of crashing the program.
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"No file named \"{fileName}\" was found. Nothing was loaded.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~");

            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._response = parts[2];
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Loaded {_entries.Count} entr{(_entries.Count == 1 ? "y" : "ies")} from \"{fileName}\".");
    }

    public void SearchEntries(string keyword)
    {
        // CREATIVITY: find every entry whose response contains a keyword.
        List<Entry> matches = new List<Entry>();

        foreach (Entry entry in _entries)
        {
            if (entry._response.ToLower().Contains(keyword.ToLower()))
            {
                matches.Add(entry);
            }
        }

        if (matches.Count == 0)
        {
            Console.WriteLine($"No entries contain \"{keyword}\".");
            return;
        }

        Console.WriteLine($"Found {matches.Count} matching entr{(matches.Count == 1 ? "y" : "ies")}:");
        Console.WriteLine();

        foreach (Entry entry in matches)
        {
            entry.Display();
        }
    }

    public void ShowStatistics()
    {
        // CREATIVITY: quick summary of the journal.
        int totalWords = 0;

        foreach (Entry entry in _entries)
        {
            totalWords += entry._response.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
        }

        Console.WriteLine($"Entries written: {_entries.Count}");
        Console.WriteLine($"Total words in all responses: {totalWords}");
    }
}
