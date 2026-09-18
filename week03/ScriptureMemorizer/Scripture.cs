public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();

        _words = new List<Word>();
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !AllWordsHidden())
        {
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public int GetWordCount()
    {
        return _words.Count;
    }

    // CREATIVITY: backs the progress indicator Program prints each round.
    public int GetHiddenWordCount()
    {
        int count = 0;

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                count++;
            }
        }

        return count;
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }
}
