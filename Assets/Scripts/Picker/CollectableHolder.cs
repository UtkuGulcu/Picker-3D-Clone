using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHolder : MonoBehaviour
{
    private List<Collectable> collectableList = new List<Collectable>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            collectableList.Add(collectable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            collectableList.Remove(collectable);
        }
    }

    public void LaunchCollectables()
    {
        foreach (Collectable collectable in collectableList)
        {
            collectable.Launch();
        }
    }

    public void ClearCollectableList()
    {
        collectableList.Clear();
    }
}
