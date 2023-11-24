using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBlockEntranceTrigger : MonoBehaviour
{
    [SerializeField] private GameEventSO OnReachedRewardArea;
    [SerializeField] private GameEventListener gameEventListener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnsubscribeColorChangeEvent();
            OnReachedRewardArea.Raise();
        }
    }

    private void UnsubscribeColorChangeEvent()
    {
        Destroy(gameEventListener);
    }
}
