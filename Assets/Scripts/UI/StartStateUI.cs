using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStateUI : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private RoundControllerService _roundControllerService;
    
    public void Init(RoundControllerService roundControllerService)
    {
        _roundControllerService = roundControllerService;
    }
    
    private void Awake()
    {
        startButton.onClick.AddListener(OnStartClick);
    }

    private void OnStartClick()
    {
        _roundControllerService.StartNewRound();
    }
}
