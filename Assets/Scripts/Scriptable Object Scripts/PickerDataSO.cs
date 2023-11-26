using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Picker Data")]
public class PickerDataSO : ScriptableObject
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float rewardAreaMinSpeed;
    public float rewardAreaMaxSpeed;
    public Vector3 defaultSize;
    public Vector3 firstBigSize;
    public Vector3 secondBigSize;
    public AnimationCurve rewardAreaSpeedCurve;
}
