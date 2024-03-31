using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsInfo
{
    private int _playerWins;
    private int _playerFalls;

    public int PlayerWins => _playerWins;
    public int PlayerFalls => _playerFalls;

    public void IncrementWins()
    {
        _playerWins++;
    }

    public void IncrementFalls()
    {
        _playerFalls++;
    }
}
