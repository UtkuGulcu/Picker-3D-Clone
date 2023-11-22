using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteUI : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnGameStarted;
    
    [SerializeField] private GameObject visuals;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonDown);
    }

    private void OnContinueButtonDown()
    {
        OnGameStarted.Raise();
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
