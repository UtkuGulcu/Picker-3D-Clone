using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void GoBackToLevelStartPosition()
    {
        transform.position = LevelManager.Instance.GetLevelStartingLocation();
    }
    
    public void OnReachedRewardArea()
    {
        playerMovement.EnableRewardAreaSpeed();
    }

    public void OnPassedRewardArea()
    {
        playerMovement.StartSlowingDown();
    }
}
