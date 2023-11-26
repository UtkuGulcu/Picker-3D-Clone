using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAreaControl : MonoBehaviour
{
    public static RewardAreaControl Instance { get; private set; }
 
    [Header("Events")]
    [SerializeField] private GameEventSO OnPickerStoppedInRewardArea;
    
    private List<RewardArea> rewardAreaList = new List<RewardArea>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are multiple Reward Area Controls!");
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RewardArea rewardArea))
        {
            rewardAreaList.Add(rewardArea);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out RewardArea rewardArea))
        {
            rewardAreaList.Remove(rewardArea);
        }
    }

    private int GetMaxReward()
    {
        if (rewardAreaList.Count == 0)
        {
            return 0;
        }
        
        int maxReward = rewardAreaList[0].GetRewardAmount();
        
        foreach (RewardArea rewardArea in rewardAreaList)
        {
            int rewardAmount = rewardArea.GetRewardAmount();

            if (rewardAmount > maxReward)
            {
                maxReward = rewardAmount;
            }
        }
        
        return maxReward;
    }

    public void OnPickerStopped()
    {
        OnPickerStoppedInRewardArea.Raise(this, GetMaxReward());
    }
}
