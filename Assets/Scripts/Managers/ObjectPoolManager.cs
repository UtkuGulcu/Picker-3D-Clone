using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }
    
    private Dictionary<int, Queue<GameObject>> poolDictionary;
    private List<GameObject> poolHolderList;

    private int currentID;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are multiple Object Pool Managers!");
            Destroy(this);
        }
        
        poolDictionary = new Dictionary<int, Queue<GameObject>>();
        poolHolderList = new List<GameObject>();
    }

    public int CreatePool(GameObject prefab, int size)
    {
        int poolID = GetUniqueID();

        while (poolDictionary.ContainsKey(poolID))
        {
            poolID = GetUniqueID();
        }

        Queue<GameObject> objectPool = new Queue<GameObject>();
        
        GameObject poolHolder = new GameObject
        {
            name = $"Pool Holder {poolID}"
        };

        poolHolderList.Add(poolHolder);

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab, poolHolder.transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        
        poolDictionary.Add(poolID, objectPool);

        return poolID;
    }
    

    public void SpawnFromPool(int poolID, Vector3 position, Vector3 eulerAngles)
    {
        if (!poolDictionary.ContainsKey(poolID))
        {
            Debug.LogError($"Pool with ID {poolID} doesn't exist.");
            return;
        }

        GameObject objectToSpawn = poolDictionary[poolID].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, Quaternion.Euler(eulerAngles));
        poolDictionary[poolID].Enqueue(objectToSpawn);

    }

    private int GetUniqueID()
    {
        return currentID++;
    }

    public void DestroyPool()
    {
        Destroy(poolHolderList[currentID - 1]);
    }
}
