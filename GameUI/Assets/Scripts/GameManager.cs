using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private string targetWord;
    [SerializeField] private Image reactionImage;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text targetText;

    private void Start() {
        UpdateTargetText(targetWord);
    }

    public void InputTextUpdated() {
        string text = inputField.text;
        reactionImage.color = targetWord.StartsWith(text) ? Color.green : Color.red;
    }
    private void UpdateTargetText(string newText) {
        targetWord = newText;
        targetText.text = newText;
    }
}
