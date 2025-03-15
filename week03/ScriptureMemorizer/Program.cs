sing System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> scriptures = LoadScriptures("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("Error: No scriptures found in file.");
            return;
        }

        Random random = new Random();
        string selectedScripture = scriptures[random.Next(scriptures.Count)];

        Scripture scripture = new Scripture(new Reference("Proverbs", 3, 5, 6), selectedScripture);

        int hideCount = ChooseDifficulty();
        
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(scripture.GetDisplayText());
            Console.ResetColor();

            Console.WriteLine($"\nWords hidden: {scripture.HiddenWordCount()} / {scripture.TotalWordCount()}");
            Console.WriteLine("Press Enter to hide words, type 'undo' to reveal last hidden words, or 'quit' to exit.");

            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;
            else if (input == "undo")
                scripture.RevealLastHiddenWords();
            else
                scripture.HideRandomWords(hideCount, random);
        }
        
        Console.WriteLine("\nAll words hidden! Well done.");
    }

    static List<string> LoadScriptures(string filePath)
    {
        return File.Exists(filePath) ? File.ReadAllLines(filePath).ToList() : new List<string>();
    }

    static int ChooseDifficulty()
    {
        Console.WriteLine("Choose difficulty level:");
        Console.WriteLine("1 - Easy (1 word at a time)");
        Console.WriteLine("2 - Medium (3 words at a time)");
        Console.WriteLine("3 - Hard (5 words at a time)");

        while (true)
        {
            Console.Write("Enter your choice (1-3): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": return 1;
                case "2": return 3;
                case "3": return 5;
                default: Console.WriteLine("Invalid choice. Please enter 1, 2, or 3."); break;
            }
        }
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse ?? startVerse;
    }

    public override string ToString()
    {
        return _endVerse == _startVerse ? $"{_book} {_chapter}:{_startVerse}" : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Stack<List<int>> _hiddenHistory = new Stack<List<int>>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords(int count, Random random)
    {
        List<int> hiddenIndexes = new List<int>();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Count == 0)
            return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            int originalIndex = _words.IndexOf(visibleWords[index]);
            visibleWords[index].Hide();
            hiddenIndexes.Add(originalIndex);
            visibleWords.RemoveAt(index);
        }

        _hiddenHistory.Push(hiddenIndexes);
    }

    public void RevealLastHiddenWords()
    {
        if (_hiddenHistory.Count > 0)
        {
            List<int> lastHidden = _hiddenHistory.Pop();
            foreach (int index in lastHidden)
            {
                _words[index].Reveal();
            }
        }
    }

    public bool AllWordsHidden() => _words.All(w => w.IsHidden);
    public int HiddenWordCount() => _words.Count(w => w.IsHidden);
    public int TotalWordCount() => _words.Count;
}

class Word
{
    private string _text;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
        IsHidden = false;
    }

    public void Hide() => IsHidden = true;
    public void Reveal() => IsHidden = false;

    public string GetDisplayText() => IsHidden ? new string('_', _text.Length) : _text;
}
