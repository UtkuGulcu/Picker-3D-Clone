using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDUI : MonoBehaviour
{
    [SerializeField] private GameObject visuals;
    [SerializeField] private TMP_Text currentLevelIndicatorText;
    [SerializeField] private TMP_Text nextLevelIndicatorText;
    [SerializeField] private CheckpointIndicator[] checkpointIndicatorArray;

    private int checkpointCount;

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
        visuals.SetActive(true);
        RefreshCheckpointIndicators();
        currentLevelIndicatorText.text = LevelManager.Instance.GetCurrentLevelCount().ToString();
        nextLevelIndicatorText.text = LevelManager.Instance.GetNextLevelCount().ToString();
    }

    public void OnCheckpointPassed()
    {
        checkpointIndicatorArray[checkpointCount].EnablePassedVisual();
        checkpointCount++;
    }

    public void RefreshCheckpointIndicators()
    {
        checkpointCount = 0;

        foreach (CheckpointIndicator checkpointIndicator in checkpointIndicatorArray)
        {
            checkpointIndicator.RefreshVisual();
        }
    }
}
