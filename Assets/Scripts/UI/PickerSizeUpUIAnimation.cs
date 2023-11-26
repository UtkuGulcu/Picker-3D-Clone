using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerSizeUpUIAnimation : MonoBehaviour
{
    [SerializeField] private GameObject visuals;
    
    private static readonly int spawnTrigger = Animator.StringToHash("spawn");
    private Animator animator;
    private int growSizeCount;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public void EnableVisuals()
    {
        LookAtCamera();
        growSizeCount ++;

        if (growSizeCount > 2)
        {
            return;
        }
        
        visuals.SetActive(true);
        animator.SetTrigger(spawnTrigger);
    }

    public void DisableVisuals()
    {
        visuals.SetActive(false);
    }

    public void ResetGrowSizeCount()
    {
        growSizeCount = 0;
    }
}
