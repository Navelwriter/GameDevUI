using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionImage : MonoBehaviour {
    private enum State { Healthy = 0, Hurt = 1, Dead = 2 };
    private Image reactionImage;
    private Animator animator;
    
    private void Awake() {
        reactionImage = GetComponent<Image>();
        animator = GetComponent<Animator>();

        InputEventBus.Subscribe(InputEventBus.EventType.ReactionCorrect, Healthy);
        InputEventBus.Subscribe(InputEventBus.EventType.ReactionWrong, Hurt);
        InputEventBus.Subscribe(InputEventBus.EventType.ReactionDie, Dead);
    }

    private void Healthy() {
        animator.SetInteger("state", (int)State.Healthy);
    }

    private void Hurt() {
        animator.SetInteger("state", (int)State.Hurt);
    }

    private void Dead() {
        animator.SetInteger("state", (int)State.Dead);
    }
}
