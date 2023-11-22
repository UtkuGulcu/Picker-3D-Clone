using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CheckpointIndicator : MonoBehaviour
{
    [SerializeField] private Image indicatorImage;
    [SerializeField] private Sprite checkpointPassedSprite;
    [SerializeField] private Sprite defaultSprite;

    public void EnablePassedVisual()
    {
        indicatorImage.sprite = checkpointPassedSprite;
    }

    public void RefreshVisual()
    {
        indicatorImage.sprite = defaultSprite;
    }
}
