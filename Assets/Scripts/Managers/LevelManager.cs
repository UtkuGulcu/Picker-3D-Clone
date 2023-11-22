using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    [SerializeField] private LevelSO defaultLevel;
    
    private LevelSO currentLevelSO;
    private GameObject currentSpawnedLevel;
    private GameObject nextSpawnedLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are multiple Level Managers!");
            Destroy(this);
        }
    }

    private void Start()
    {
        if (currentLevelSO == null)
        {
            currentLevelSO = defaultLevel;
            SpawnCurrentLevel();
        }
    }

    public void OnLevelPassed()
    {
        currentLevelSO = currentLevelSO.nextLevel;
        nextSpawnedLevel = Instantiate(currentLevelSO.prefab, currentLevelSO.spawnPosition, Quaternion.identity);
    }

    public void RespawnLevel()
    {
        Destroy(currentSpawnedLevel);
        SpawnCurrentLevel();
    }

    public void DestroyPreviousLevel()
    {
        Destroy(currentSpawnedLevel);
        currentSpawnedLevel = nextSpawnedLevel;
    }

    public Vector3 GetLevelStartingLocation()
    {
        return currentLevelSO.spawnPosition;
    }

    private void SpawnCurrentLevel()
    {
        currentSpawnedLevel = Instantiate(currentLevelSO.prefab, currentLevelSO.spawnPosition, Quaternion.identity);
    }

    public int GetCurrentLevelCount()
    {
        return currentLevelSO.levelCount;
    }
    
    public int GetNextLevelCount()
    {
        return currentLevelSO.nextLevel.levelCount;
    }
}
