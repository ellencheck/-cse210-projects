using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords()
    {
        // Randomly hide 1 to 4 words
        int numWordsToHide = _random.Next(1, 5); // Random number between 1 and 4
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Any())
        {
            for (int i = 0; i < numWordsToHide; i++)
            {
                if (visibleWords.Any())  // Ensure there are still visible words to hide
                {
                    int index = _random.Next(visibleWords.Count);
                    visibleWords[index].Hide();
                    visibleWords.RemoveAt(index);  // Remove the hidden word from the list to avoid hiding the same word
                }
            }
        }
    }

    public bool AllWordsHidden() => _words.All(w => w.IsHidden);
}
