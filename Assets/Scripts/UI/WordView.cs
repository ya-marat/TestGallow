using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordView : MonoBehaviour
{
    [SerializeField] private LetterItem letterItem;

    private List<LetterItem> currentLetters = new();
    private GameRoundService _gameRoundService;
    private WordService _wordService;
    
    public void Init(GameRoundService gameRoundService, WordService wordService, StateMachine stateMachine)
    {
        _gameRoundService = gameRoundService;
        _wordService = wordService;
        _gameRoundService.RightLetterInput += RightLetterInput;
        stateMachine.NewStateActivated += ActivatedNewState;
    }

    private void ActivatedNewState(GameState state)
    {
        if (state == GameState.Game)
        {
            InitLetters(_wordService.CurrentWord.Length);
            Debug.Log($"Word {_wordService.CurrentWord}");
        }
    }

    private void RightLetterInput(List<LetterIndex> letters)
    {
        foreach (var letter in letters)
        {
            currentLetters[letter.index].SetLetter(letter.letter);
        }
    }

    private void InitLetters(int lettersCount)
    {
        foreach (var letter in currentLetters)
        {
            Destroy(letter.gameObject);
        }
        
        currentLetters.Clear();

        for (int i = 0; i < lettersCount; i++)
        {
            var letter = Instantiate(letterItem, transform);
            currentLetters.Add(letter);
        }
    }
}
