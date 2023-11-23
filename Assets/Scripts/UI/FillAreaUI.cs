using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillAreaUI : MonoBehaviour
{
    [SerializeField] private TMP_Text collectedCountText;
    [SerializeField] private TMP_Text requiredCollectableText;

    private void Start()
    {
        collectedCountText.text = "0";
    }

    public void SetupRequiredCollectableText(int requiredCollectableCount)
    {
        requiredCollectableText.text = requiredCollectableCount.ToString();
    }

    public void UpdateText(int collectedCount)
    {
        collectedCountText.text = collectedCount.ToString();
    }
}