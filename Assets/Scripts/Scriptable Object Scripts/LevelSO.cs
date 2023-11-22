using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Level")]
public class LevelSO : ScriptableObject
{
    public GameObject prefab;
    public int levelCount;
    public LevelSO nextLevel;
    public Vector3 spawnPosition;
}
