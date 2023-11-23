using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntranceBarrierAnimation : MonoBehaviour
{
    private Animator animator;
    private static readonly int openTrigger = Animator.StringToHash("open");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayOpeningAnimation()
    {
        animator.SetTrigger(openTrigger);
    }
}
