using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Level")]
public class LevelSO : ScriptableObject
{
    [Header("References")]
    public GameObject prefab;
    public LevelSO nextLevel;
    
    [Header("Values")]
    public int levelCount;
    public Vector3 spawnPosition;
    public Color color;
    
    
    [Header("Fill Area Requirements")]
    public int firstFillAreaRequirement;
    public int secondFillAreaRequirement;
    public int thirdFillAreaRequirement;
    

    public int GetFillAreaRequirement(FillArea.Type type)
    {
        return type switch
        {
            FillArea.Type.First => firstFillAreaRequirement,
            FillArea.Type.Second => secondFillAreaRequirement,
            FillArea.Type.Third => thirdFillAreaRequirement,
            _ => 0
        };
    }
}
