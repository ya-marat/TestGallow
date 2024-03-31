using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private GameState _currentState;

    public event Action<GameState> NewStateActivated; 

    public void MoveToState(GameState newState)
    {
        _currentState = newState;
        NewStateActivated?.Invoke(newState);
    }
}
