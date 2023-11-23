using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public static event EventHandler OnGameStarted;
    
    //[SerializeField] private GameEventSO OnGameStarted;
    [SerializeField] private GameObject visuals;

    private bool isGamePaused = true;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGamePaused)
        {
            //OnGameStarted.Raise();
            OnGameStarted.Invoke(this, EventArgs.Empty);
            HideVisuals();
            isGamePaused = false;
        }
    }

    public void OnGamePaused()
    {
        isGamePaused = true;
        ShowVisuals();
    }

    private void HideVisuals()
    {
        visuals.SetActive(false);
    }

    private void ShowVisuals()
    {
        visuals.SetActive(true);
    }
}
