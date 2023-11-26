using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnResourceChanged;
    
    public enum ResourceType
    {
        Diamond
    }

    public static ResourceManager Instance { get; private set; }
    
    private Dictionary<ResourceType, int> resourceDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are multiple Resource Managers!");
            Destroy(this);
        }

        resourceDictionary = new Dictionary<ResourceType, int>
        {
            [ResourceType.Diamond] = 0
        };
    }

    public void IncreaseDiamond(object sender, object data)
    {
        int addedAmount = (int)data;
        int newAmount = resourceDictionary[ResourceType.Diamond];
        newAmount += addedAmount;

        resourceDictionary[ResourceType.Diamond] = newAmount;
        
        OnResourceChanged.Raise(this, newAmount);
    }

    public int GetDiamondAmount()
    {
        return resourceDictionary[ResourceType.Diamond];
    }

    public void SetDiamondAmount(int amount)
    {
        resourceDictionary[ResourceType.Diamond] = amount;
    }
}
