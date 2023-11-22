using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillAreaEntranceTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FillArea fillArea;
    
    [Header("Events")]
    [SerializeField] private GameEventSO OnReachedFillArea;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnReachedFillArea.Raise();
            StartCoroutine(fillArea.CheckWinState());
        }
    }
}
