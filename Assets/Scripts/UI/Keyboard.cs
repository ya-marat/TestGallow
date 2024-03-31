using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private KeyboardKey keyboardKeyPrefab;

    private List<KeyboardKey> _keyboardKeys = new();
    private GameRoundService _gameRoundService;

    private readonly char[] _symbols = {
        'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М',
        'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
        'Ы', 'Ь', 'Э', 'Ю', 'Я'
    };
    
    public void Init(GameRoundService gameRoundService)
    {
        _gameRoundService = gameRoundService;
    }
    
    private void Awake()
    {
        SpawnKeyboardKeys();
    }

    private void OnKeyClicked(KeyboardKey key)
    {
        _gameRoundService.CheckLetter(key.KeySymbol);
    }

    private void SpawnKeyboardKeys()
    {
        foreach (var symbol in _symbols)
        {
            var key = Instantiate(keyboardKeyPrefab, transform);
            key.gameObject.SetActive(true);
            key.Init(symbol);
            key.OnKeyClick += OnKeyClicked;
            _keyboardKeys.Add(key);
        }
    }
}
