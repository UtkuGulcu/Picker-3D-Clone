using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerEntranceTrigger : MonoBehaviour
{
    [SerializeField] private CollectableSpawner collectableSpawner;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectableSpawner.EnableSpawning();
            Destroy(this);
        }
    }
}
