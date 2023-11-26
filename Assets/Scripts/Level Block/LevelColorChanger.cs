using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] levelBlockMeshRendererArray;
    [SerializeField] private MeshRenderer rewardAreaMeshRenderer;

    public void SetLevelColor(LevelSO levelSO)
    {
        SetLevelBlocksColor(levelBlockMeshRendererArray, levelSO.color);

        rewardAreaMeshRenderer.material.color = levelSO.nextLevel == null ? levelSO.color : levelSO.nextLevel.color;
    }

    private void SetLevelBlocksColor(MeshRenderer[] meshRendererArray, Color levelColor)
    {
        foreach (MeshRenderer meshRenderer in meshRendererArray)
        {
            meshRenderer.material.color = levelColor;
        }
    }
}
