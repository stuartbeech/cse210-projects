class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(' ');

        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> unhiddenWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                unhiddenWords.Add(word);
            }
        }

        Random random = new Random();

        int count = Math.Min(numberToHide, unhiddenWords.Count);

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(unhiddenWords.Count);
            Word wordToHide = unhiddenWords[index];

            wordToHide.Hide();
        }
    }

    public bool IsCompletelyHidden()
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

    public string GetDisplayText()
    {
        string displayWords = "";

        foreach (Word word in _words)
        {
            displayWords += word.GetDisplayText() + " ";
        }

        return _reference.GetDisplayText() + "\n" + displayWords;
    }
}