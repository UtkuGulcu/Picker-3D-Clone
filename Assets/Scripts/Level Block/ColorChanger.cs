using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool isLastBlock;

    public void SetColor(object sender, object data)
    {
        LevelSO levelSO = data as LevelSO;

        if (levelSO.nextLevel == null)
        {
            meshRenderer.material.color = levelSO.color;
            return;
        }
        
        meshRenderer.material.color = isLastBlock ? levelSO.nextLevel.color : levelSO.color;
    }
}
