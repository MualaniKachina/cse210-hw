using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

    public void HideRandomWords(int count = 3)
    {
        var available = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && available.Count > 0; i++)
        {
            int index = _rand.Next(available.Count);
            available[index].Hide();
            available.RemoveAt(index);
        }
    }

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
