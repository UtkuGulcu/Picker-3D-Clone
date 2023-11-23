using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBlockVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    public void SetColor(object sender, object data)
    {
        LevelSO levelSO = data as LevelSO;
        meshRenderer.material.color = levelSO.nextLevel.color;
    }
}
