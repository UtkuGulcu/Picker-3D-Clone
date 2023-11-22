using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class CollectablePackGenerator : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private GameObject collectable;
    
    [Space(10f)]
    [SerializeField] private PackType packType;
    
    public enum PackType
    {
        Line,
        Grid
    }

    [Header("Line Values")]
    [SerializeField] private int length;

    [Header("Grid Values")] 
    [SerializeField] private int width;
    [SerializeField] private int height;

    private void Start()
    {
        Destroy(this);
    }

    public void GenerateLine()
    {
        if (length == 0)
        {
            Debug.LogWarning("Length must be greater than zero");
        }

        float distance = 0.35f;
        
        for (int i = 0; i < length; i++)
        {
            GameObject spawnedObject = PrefabUtility.InstantiatePrefab(collectable, transform) as GameObject;
            spawnedObject.transform.position = Vector3.zero + new Vector3(0, 0, distance * i);
        }

        PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.UserAction);
    }

    public void GenerateGrid()
    {
        float distance = 0.4f;
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject spawnedObject = PrefabUtility.InstantiatePrefab(collectable, transform) as GameObject;
                spawnedObject.transform.position = Vector3.zero + new Vector3(i * distance, 0, j * distance);
            }
        }
        
        PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.UserAction);
    }
}
