using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoundControllerService
{
    private readonly ResultService _resultService;
    private readonly WordService _wordService;
    private readonly StateMachine _stateMachine;
    private readonly PlayerStatsInfo _playerStatsInfo;

    [Inject]
    public RoundControllerService(ResultService resultService, WordService wordService, StateMachine stateMachine, PlayerStatsInfo playerStatsInfo)
    {
        _resultService = resultService;
        _wordService = wordService;
        _stateMachine = stateMachine;
        _playerStatsInfo = playerStatsInfo;
    }

    public void StartNewRound()
    {
        _wordService.GetNewWord();
        _stateMachine.MoveToState(GameState.Game);
    }

    public void EndRound()
    {
        bool isWin = _resultService.IsWin;
        if (isWin)
        {
            _playerStatsInfo.IncrementWins();
        }
        else
        {
            _playerStatsInfo.IncrementFalls();
        }
        
        _stateMachine.MoveToState(GameState.Result);
    }
}
