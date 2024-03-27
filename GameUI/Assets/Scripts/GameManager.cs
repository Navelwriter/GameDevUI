using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private string targetWord;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private TMP_InputField inputField;
    private int lives;
    private void Start() {
        lives = maxLives;
    }

    public void InputTextUpdated() {
        string text = inputField.GetComponent<TMP_InputField>().text;
        if (!targetWord.StartsWith(text)) {
            lives--;
        }
    }
}
