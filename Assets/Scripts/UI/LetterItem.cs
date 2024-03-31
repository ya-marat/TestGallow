using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterItem : MonoBehaviour
{
    [SerializeField] private Text letterView;

    private char currentLetter;

    public char CurrentLetter => currentLetter;

    private void Awake()
    {
        letterView.gameObject.SetActive(false);
    }

    public void SetLetter(char letter)
    {
        letterView.gameObject.SetActive(true);
        currentLetter = letter;
        letterView.text = letter.ToString();
    }
}