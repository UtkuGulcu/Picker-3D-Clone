using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardAreaUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text rewardText;

    public void SetupText(int rewardAmount)
    {
        rewardText.text = rewardAmount.ToString();
    }
}
