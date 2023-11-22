using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameEventSO OnGameStarted;
    [SerializeField] private GameObject visuals;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnGameStarted.Raise();
            HideVisuals();
            enabled = false;
        }
    }

    private void HideVisuals()
    {
        visuals.SetActive(false);
    }

    public void ShowVisuals()
    {
        visuals.SetActive(true);
    }
}
