using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LetterIndex
{
    public char letter;
    public int index;

    public LetterIndex(char letter, int index)
    {
        this.letter = letter;
        this.index = index;
    }
}
