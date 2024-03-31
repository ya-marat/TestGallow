using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameStateUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Keyboard keyboardView;
    [SerializeField] private WordView wordView;
    [SerializeField] private HangManView hangManView;
    [SerializeField] private RectTransform restartView;
    [SerializeField] private Text winStatusText;
    [SerializeField] private Text playerStatus;
    
    private PlayerStatsInfo _playerStatsInfo;
    private StateMachine _stateMachine;
    private ResultService _resultService;
    private RoundControllerService _roundControllerService;
    
    public void Init(GameRoundService gameRoundService, WordService wordService, PlayerStatsInfo playerStatsInfo, 
        StateMachine stateMachine, ResultService resultService, RoundControllerService roundControllerService)
    {
        _playerStatsInfo = playerStatsInfo;
        _stateMachine = stateMachine;
        _resultService = resultService;
        _roundControllerService = roundControllerService;
        
        keyboardView.Init(gameRoundService);
        wordView.Init(gameRoundService, wordService, stateMachine);
        hangManView.Init(gameRoundService, stateMachine);

        _stateMachine.NewStateActivated += ActivatedNewState;
        
        UpdatePlayerStatus();
    }

    private void ActivatedNewState(GameState state)
    {
        switch (state)
        {
            case GameState.Game:
                restartView.gameObject.SetActive(false);
                keyboardView.gameObject.SetActive(true);
                break;
            case GameState.Result:
                restartView.gameObject.SetActive(true);
                keyboardView.gameObject.SetActive(false);
                winStatusText.text = _resultService.IsWin ? "Победа" : "Поражение";
                UpdatePlayerStatus();
                break;
        }
    }

    private void Awake()
    {
        restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        _roundControllerService.StartNewRound();
    }

    private void UpdatePlayerStatus()
    {
        playerStatus.text = $"Побед {_playerStatsInfo.PlayerWins} : Поражений {_playerStatsInfo.PlayerFalls}";
    }
}
