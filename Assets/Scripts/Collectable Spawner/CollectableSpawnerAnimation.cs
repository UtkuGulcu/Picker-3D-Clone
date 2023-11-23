using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerAnimation : MonoBehaviour
{
    private Animator animator;
    private static int zigZagTrigger = Animator.StringToHash("zigZag");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayZigZagAnimation()
    {
        animator.SetTrigger(zigZagTrigger);
    }

    // Animation Event: Gets Triggered when Fly Up Animation is finished.
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
