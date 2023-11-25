using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject pooledObjectPrefab;
    [SerializeField] private int poolSize;

    private Queue<GameObject> objectPool;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject spawnedGameObject = Instantiate(pooledObjectPrefab);
            spawnedGameObject.SetActive(false);
            objectPool.Enqueue(spawnedGameObject);
        }
    }

    public GameObject SpawnObjectFromPool(Vector3 position, Vector3 eulerAngles)
    {
        GameObject objectToSpawn = objectPool.Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, Quaternion.Euler(eulerAngles));
        
        objectPool.Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
