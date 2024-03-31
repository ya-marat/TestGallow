using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultService
{
    private bool _isWin;

    public bool IsWin => _isWin;

    public void SetResult(bool isWin)
    {
        _isWin = isWin;
    }
}
