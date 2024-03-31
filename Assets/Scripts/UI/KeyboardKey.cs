using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class KeyboardKey : MonoBehaviour
{
    [SerializeField] private Text _keyText;

    private Button _button;
    private char keySymbol;

    public char KeySymbol => keySymbol;
    public event Action<KeyboardKey> OnKeyClick; 

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    public void Init(char key)
    {
        keySymbol = key;
        _keyText.text = key.ToString();
    }

    private void OnButtonClick()
    {
        OnKeyClick?.Invoke(this);
    }
}
