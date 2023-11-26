using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillArea : MonoBehaviour
{
    public enum Type
    {
        First,
        Second,
        Third
    }
    
    [Header("References")]
    [SerializeField] private FillAreaUI fillAreaUI;
    [SerializeField] private FillAreaAnimation fillAreaAnimation;

    [Header("Events")]
    [SerializeField] private GameEventSO OnLevelFailed;

    [Header("Which Section?")]
    [SerializeField] private Type type;

    private int requiredCollectables;
    private int collectableCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            collectableCount++;
            UpdateText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            collectableCount--;
            UpdateText();
        }
    }

    public void CheckWinState()
    {
        StartCoroutine(WaitToCheckWinState());
    }

    private IEnumerator WaitToCheckWinState()
    {
        float waitTime = 1.5f;
        yield return Helpers.GetWait(waitTime);
        
        if (collectableCount >= requiredCollectables)
        {
            fillAreaAnimation.PlayWinAnimation();
        }
        else
        {
            OnLevelFailed.Raise();
        }
    }
    
    private void UpdateText()
    {
        fillAreaUI.UpdateText(collectableCount);
    }

    public void SetFillAreaRequirement()
    {
        LevelSO levelSO = LevelManager.Instance.GetCurrentLevel();
        requiredCollectables = levelSO.GetFillAreaRequirement(type);
        fillAreaUI.SetupRequiredCollectableText(requiredCollectables);
    }
}
