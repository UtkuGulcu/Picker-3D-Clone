using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnGameLoaded;

    [Header("References")]
    [SerializeField] private LevelSO defaultLevel;
    
    private class SaveObject
    {
        //public LevelSO levelSO;
        public int levelCount;
    }
    
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are multiple Save Managers!");
            Destroy(this);
        }
        
        SaveSystem.Initialize();
    }
    
    private void Start()
    {
        Load();
        OnGameLoaded.Raise();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            return;
        }

        Save();
    }

    private void Save()
    {
        int currentLevelCount = LevelManager.Instance.GetCurrentLevelCount();

        SaveObject saveObject = new SaveObject
        {
            levelCount = currentLevelCount
        };

        string jsonString = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(jsonString);
    }

    private void Load()
    {
        if (SaveSystem.IsNewGame())
        {
            LevelManager.Instance.SetCurrentLevel(1);
            return;
        }
        
        string jsonString = SaveSystem.Load();

        if (jsonString == null)
        {
            Debug.LogError("Corrupted Save file");
        }

        SaveObject loadedObject = JsonUtility.FromJson<SaveObject>(jsonString);
        
        LevelManager.Instance.SetCurrentLevel(loadedObject.levelCount);
    }

    public void DeleteSaves()
    {
        
    }
}
