using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private GameObject visuals;
    
    [Header("Events")]
    [SerializeField] private GameEventSO OnLevelRetried;

    private void Start()
    {
        tryAgainButton.onClick.AddListener(OnTryAgainButtonDown);
    }

    private void OnTryAgainButtonDown()
    {
        OnLevelRetried.Raise();
        HideVisuals();
    }

    public void ShowVisuals()
    {
        visuals.SetActive(true);
    }

    private void HideVisuals()
    {
        visuals.SetActive(false);
    }
}
