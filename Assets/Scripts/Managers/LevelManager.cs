using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnLevelLoaded;
    
    public static LevelManager Instance { get; private set; }
    
    [SerializeField] private LevelSO[] levelSOArray;
    
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

    public void OnGameLoaded()
    {
        if (currentLevelSO == null)
        {
            currentLevelSO = levelSOArray[0];
        }
        
        SpawnCurrentLevel();
    }

    public void SpawnNextLevel()
    {
        currentLevelSO = currentLevelSO.nextLevel;
        nextSpawnedLevel = Instantiate(currentLevelSO.prefab, currentLevelSO.spawnPosition, Quaternion.identity);
        
        LevelColorChanger levelColorChanger = nextSpawnedLevel.GetComponent<LevelColorChanger>();
        levelColorChanger.SetLevelColor(currentLevelSO);
        
        OnLevelLoaded.Raise(this, currentLevelSO);
    }

    public void RespawnLevel()
    {
        Destroy(currentSpawnedLevel);
        SpawnCurrentLevel();
    }
    
    private void SpawnCurrentLevel()
    {
        currentSpawnedLevel = Instantiate(currentLevelSO.prefab, currentLevelSO.spawnPosition, Quaternion.identity);
        
        LevelColorChanger levelColorChanger = currentSpawnedLevel.GetComponent<LevelColorChanger>();
        levelColorChanger.SetLevelColor(currentLevelSO);
        
        OnLevelLoaded.Raise(this, currentLevelSO);
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

    public void SetCurrentLevel(int loadedLevelCount)
    {
        currentLevelSO = levelSOArray[loadedLevelCount - 1];
    }

    public int GetCurrentLevelCount()
    {
        return currentLevelSO.levelCount;
    }

    public LevelSO GetCurrentLevel()
    {
        return currentLevelSO;
    }
    
    public int GetNextLevelCount()
    {
        return currentLevelSO.nextLevel == null ? currentLevelSO.levelCount : currentLevelSO.nextLevel.levelCount;
    }
}
