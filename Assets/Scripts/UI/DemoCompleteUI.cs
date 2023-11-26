using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoCompleteUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject visuals;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    private void Start()
    { 
        playAgainButton.onClick.AddListener(OnPlayAgainButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnPlayAgainButtonClicked()
    {
        SaveSystem.DeleteSaves();
        SceneLoader.ReloadScene();
    }

    private void OnQuitButtonClicked()
    {
        SaveManager.Instance.Save();
        Application.Quit();
    }

    public void EnableVisuals()
    {
        visuals.SetActive(true);
    }
}
