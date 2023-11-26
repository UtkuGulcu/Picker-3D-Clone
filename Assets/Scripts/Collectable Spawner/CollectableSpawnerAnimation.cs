using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerAnimation : MonoBehaviour
{
    private Animator animator;
    private static readonly int zigZagMovementTrigger = Animator.StringToHash("zigZagMovement");
    private static readonly int curvedMovementTrigger = Animator.StringToHash("curvedMovement");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayZigZagMovementAnimation()
    {
        animator.SetTrigger(zigZagMovementTrigger);
    }

    public void PlayCurvedMovementAnimation()
    {
        animator.SetTrigger(curvedMovementTrigger);
    }

    // Animation Event: Gets Triggered when Fly Up Animation is finished.
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
