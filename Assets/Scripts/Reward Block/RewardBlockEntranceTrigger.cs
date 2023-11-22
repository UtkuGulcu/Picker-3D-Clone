using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBlockEntranceTrigger : MonoBehaviour
{
    [SerializeField] private GameEventSO OnReachedRewardArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnReachedRewardArea.Raise();
        }
    }
}
