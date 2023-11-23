using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMultiplierTrigger : MonoBehaviour
{
    [SerializeField] private CollectableMultiplier collectableMultiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectableMultiplier.SpawnSmallCollectables();
        }
    }
}
