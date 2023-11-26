using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RewardBlockExitTrigger : MonoBehaviour
{
    [SerializeField] private GameEventSO OnPassedRewardBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPassedRewardBlock.Raise();
        }
    }
}
