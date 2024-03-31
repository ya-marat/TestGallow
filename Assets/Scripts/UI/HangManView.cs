using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HangManView : MonoBehaviour
{
    [Serializable]
    public class StateImage
    {
        [SerializeField] private int stateIndex;
        [SerializeField] private Image stateImg;

        public int Index => stateIndex;
        public Image StateImg => stateImg;
    }

    [SerializeField] private StateImage[] stateImages;

    private GameRoundService _gameRoundService;
    
    public void Init(GameRoundService gameRoundService, StateMachine stateMachine)
    {
        _gameRoundService = gameRoundService;
        _gameRoundService.WrongLetterInput += GameRoundServiceOnWrongLetterInput;
        stateMachine.NewStateActivated += ActivatedNewState;
    }

    private void ActivatedNewState(GameState state)
    {
        if (state == GameState.Game)
        {
            StartNewRound();
        }
    }

    private void GameRoundServiceOnWrongLetterInput(int errorsCount)
    {
        stateImages[errorsCount - 1].StateImg.gameObject.SetActive(true);
    }

    private void StartNewRound()
    {
        foreach (var stateImage in stateImages)
        {
            stateImage.StateImg.gameObject.SetActive(false);
        }
    }
}
