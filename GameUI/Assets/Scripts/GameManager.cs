using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text targetText;
    [SerializeField] private int health = 3;
    [SerializeField] private string targetWord;

    private void Start() {
        UpdateTargetText(targetWord);
    }

    public void InputTextUpdated() {
        // If the input text matches the target text
        if (targetWord.StartsWith(inputField.text)) {
            InputEventBus.Publish(InputEventBus.EventType.ReactionCorrect);
            return;
        }

        // If the input text does not match the target text but the health is greater than zero
        health--;
        if (health > 0) {
            InputEventBus.Publish(InputEventBus.EventType.ReactionWrong);
            return;
        }

        // If the input text does not match the target text and the health is less than or equal to zero
        InputEventBus.Publish(InputEventBus.EventType.ReactionDie);
    }
    
    private void UpdateTargetText(string newText) {
        targetWord = newText;
        targetText.text = newText;
    }
}
