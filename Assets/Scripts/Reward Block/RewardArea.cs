using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardArea : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RewardAreaDataSO rewardAreaDataSO;
    [SerializeField] private RewardAreaUI rewardAreaUI;
    [SerializeField] private MeshRenderer backgroundMeshRenderer;
    
    [Header("Values")]
    [SerializeField] private int rewardAmount;

    private void Start()
    {
        rewardAreaUI.SetupText(rewardAmount);
        backgroundMeshRenderer.material.color = rewardAreaDataSO.GetColor(rewardAmount);
    }

    public int GetRewardAmount()
    {
        return rewardAmount; 
    }
}
