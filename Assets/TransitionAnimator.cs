using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimator : MonoBehaviour
{

    public enum TransitionStates { longFadeOut, fadeOut, fadeIn}
    public TransitionStates currentState = TransitionStates.longFadeOut;

    public bool playAtStart = false;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (!playAtStart) return;

        TypeToPlay();
    }

    public void TypeToPlay()
    {
        switch (currentState)
        {
            case TransitionStates.longFadeOut:
                animator.Play("Transition Screen Fade Out");
                break;

            case TransitionStates.fadeOut:
                animator.Play("Transition Out");
                break;

            case TransitionStates.fadeIn:
                animator.Play("Transition In");
                break;
        }
    }
}
