public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // CREATIVITY: only letters/digits become underscores, so
        // punctuation (like the period in "life.") stays visible as
        // "____." instead of disappearing into "_____". That keeps the
        // verse's punctuation as a memory cue even once every word is hidden.
        char[] characters = _text.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            if (char.IsLetterOrDigit(characters[i]))
            {
                characters[i] = '_';
            }
        }

        return new string(characters);
    }
}
