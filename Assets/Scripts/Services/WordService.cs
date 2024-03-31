using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordService
{
    private List<string> _words = new()
    {
        "сундук",
        "покер",
        "вилы",
        "румба",
        "карамба",
    };

    private List<string> availableWords = new List<string>();
    private string _currentWord;

    public string CurrentWord => _currentWord;

    private void InitAvailableWords()
    {
        foreach (var word in _words)
        {
            var newWord = word.ToUpper();
            availableWords.Add(newWord);
        }
    }

    public void GetNewWord()
    {
        if (availableWords.Count == 0)
        {
            InitAvailableWords();
        }
        
        int randomIndex = Random.Range(0, availableWords.Count);
        string word = availableWords[randomIndex];
        _currentWord = word;
        availableWords.RemoveAt(randomIndex);
    }
}
