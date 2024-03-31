using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class MainUI : MonoBehaviour
{
    [SerializeField] private StartStateUI startStateUI;
    [SerializeField] private GameStateUI gameStateUI;
    

    [Inject]
    public void Init(GameRoundService gameRoundService, WordService wordService, PlayerStatsInfo playerStatsInfo, StateMachine stateMachine, 
        RoundControllerService roundControllerService, ResultService resultService)
    {
        startStateUI.Init(roundControllerService);
        gameStateUI.Init(gameRoundService, wordService, playerStatsInfo, stateMachine, resultService, roundControllerService);
        
        stateMachine.NewStateActivated += ActivatedNewState;
    }

    private void ActivatedNewState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                startStateUI.gameObject.SetActive(true);
                gameStateUI.gameObject.SetActive(false);
                break;
            case GameState.Game:
                startStateUI.gameObject.SetActive(false);
                gameStateUI.gameObject.SetActive(true);
                break;
        }
    }
}
