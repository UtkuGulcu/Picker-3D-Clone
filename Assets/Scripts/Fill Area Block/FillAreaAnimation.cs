using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillAreaAnimation : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnPassedFillArea;
    [SerializeField] private GameEventSO OnFillAreaSuccessUIEnabled;
    
    private Animator animator;
    private static readonly int winTrigger = Animator.StringToHash("win");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayWinAnimation()
    {
        animator.SetTrigger(winTrigger);
    }

    // Animation Event
    public void OnAnimationFinished()
    {
        OnPassedFillArea.Raise();
    }

    // Animation Event 
    public void OnBarrierOpen()
    {
        OnFillAreaSuccessUIEnabled.Raise();
    }
}
