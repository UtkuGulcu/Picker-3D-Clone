using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RewardBlockEntranceTrigger : MonoBehaviour
{
    [SerializeField] private GameEventSO OnReachedRewardBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnReachedRewardBlock.Raise();
        }
    }
}
