using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillAreaSuccessUIAnimation : MonoBehaviour
{
    private Animator animator;
    private static int spawnTrigger = Animator.StringToHash("spawn");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlaySpawnAnimation()
    {
        animator.SetTrigger(spawnTrigger);
    }
}
