using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameRoundService
{
    private const int MaxErrorsCount = 6;
    
    private readonly WordService _wordService;
    private readonly ResultService _resultService;
    private readonly StateMachine _stateMachine;
    private readonly RoundControllerService _roundControllerService;
    private List<LetterIndex> _rightLetters = new();
    private int _errorsCount;
    private string _currentWord;

    public event Action<List<LetterIndex>> RightLetterInput;
    public event Action<int> WrongLetterInput; 

    [Inject]
    public GameRoundService(WordService wordService, ResultService resultService, StateMachine stateMachine, RoundControllerService roundControllerService)
    {
        _wordService = wordService;

        _resultService = resultService;
        _stateMachine = stateMachine;
        _roundControllerService = roundControllerService;
        _stateMachine.NewStateActivated += ActivatedNewState;
    }

    private void ActivatedNewState(GameState state)
    {
        if (state == GameState.Game)
        {
            InitNewRound();
        }
    }

    private void InitNewRound()
    {
        _rightLetters.Clear();
        _errorsCount = 0;
        _currentWord = _wordService.CurrentWord;
    }
    
    public void CheckLetter(char letter)
    {
        List<LetterIndex> letterIndices = new List<LetterIndex>();

        if (_rightLetters.Any(e => e.letter == letter))
        {
            return;
        }
        
        for (var i = 0; i < _currentWord.Length; i++)
        {
            var wordLetter = _currentWord[i];
            if (letter == wordLetter)
            {
                letterIndices.Add(new LetterIndex(wordLetter, i));
            }
        }

        if (letterIndices.Count > 0)
        {
            _rightLetters.AddRange(letterIndices);
            RightLetterInput?.Invoke(letterIndices);
        }
        else
        {
            _errorsCount++;
            WrongLetterInput?.Invoke(_errorsCount);
            
            if (_errorsCount > MaxErrorsCount)
            { 
                SetRoundEnd(false);
                return;
            }
        }
        
        if (CheckWin())
        {
            SetRoundEnd(true);
        }
    }

    private bool CheckWin()
    {
        bool sameSize = _wordService.CurrentWord.Length == _rightLetters.Count;

        if (!sameSize)
        {
            return false;
        }
        
        for (var i = 0; i < _currentWord.Length; i++)
        {
            var letterCurrentWord = _currentWord[i];
            var letterInRightLetter = _rightLetters.FirstOrDefault(e => e.index == i).letter;
            if (letterCurrentWord != letterInRightLetter)
            {
                return false;
            }
        }

        return true;
    }

    private void SetRoundEnd(bool isWin)
    {
        _resultService.SetResult(isWin);
        _roundControllerService.EndRound();
    }
}
