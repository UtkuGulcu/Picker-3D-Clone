using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        StartUI.OnGameStarted += OnGameStarted;
        LevelCompleteUI.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        StartUI.OnGameStarted -= OnGameStarted;
        LevelCompleteUI.OnGameStarted -= OnGameStarted;
    }

    private void OnGameStarted(object sender, EventArgs e)
    {
        playerMovement.enabled = true;
        playerInput.enabled = true;
    }

    public void GoBackToLevelStartPosition()
    {
        transform.position = LevelManager.Instance.GetLevelStartingLocation();
        float floorOffset = 0.173f;
        transform.position += new Vector3(0, floorOffset, 0);
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
