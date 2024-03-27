using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private string targetWord;
    [SerializeField] private Image reactionImage;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text targetText;
    //Create list of images that are from a sprite sheet
    [SerializeField] private Sprite healthyImage;
    [SerializeField] private Sprite damagedImage;
    [SerializeField] private Sprite destroyedImage;


    private void Start() {
        UpdateTargetText(targetWord);
        //set the image to the healthy sprite
        reactionImage.sprite = healthyImage;
        

        
    }

    public void InputTextUpdated() {
        string text = inputField.text;
        for (int i = 0; i < text.Length; i++) {
            if (i < targetWord.Length) {
                if (text[i] != targetWord[i]) {
                    //if the character is incorrect, reduce health
                    maxHealth--;
                    //color the text red
                    inputField.textComponent.color = Color.red;
                    break;
                }
                //color the text white if it is correct
                inputField.textComponent.color = Color.white;
            } else {
                //if the input is longer than the target word, reduce health
                maxHealth--;
                break;
            }
        }

        if (maxHealth == 2) {
            reactionImage.sprite = damagedImage;
        } else if (maxHealth == 1) {
            reactionImage.sprite = destroyedImage;
        }
    }
    
    private void UpdateTargetText(string newText) {
        targetWord = newText;
        targetText.text = newText;
    }
}
