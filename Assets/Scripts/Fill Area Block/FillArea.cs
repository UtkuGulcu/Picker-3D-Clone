using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillArea : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FillAreaUI fillAreaUI;
    [SerializeField] private FillAreaAnimation fillAreaAnimation;

    [Header("Events")]
    [SerializeField] private GameEventSO OnLevelFailed;

    [Header("Values")]
    [SerializeField] private int requiredCollectables;
    
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

    public int GetRequiredCollectables()
    {
        return requiredCollectables;
    }

    public IEnumerator CheckWinState()
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
}
