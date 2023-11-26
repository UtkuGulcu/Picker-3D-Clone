using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Reward Area Data")]
public class RewardAreaDataSO : ScriptableObject
{
    public Color firstColor;
    public Color secondColor;
    public Color thirdColor;
    public Color fourthColor;

    public Color GetColor(int rewardAmount)
    {
        if (rewardAmount < 200)
        {
            return firstColor;
        }
        
        if (rewardAmount < 300)
        {
            return secondColor;
        }
        
        if (rewardAmount < 400)
        {
            return thirdColor;
        }
        
        if (rewardAmount < 500)
        {
            return fourthColor;
        }

        return firstColor;
    }
}
