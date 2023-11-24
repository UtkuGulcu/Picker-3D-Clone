using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Fill Area Success UI Data")]
public class FillAreaSuccessUIDataSO : ScriptableObject
{
    public string[] possibleTextArray;

    public string GetRandomText()
    {
        int randomIndex = Random.Range(0, possibleTextArray.Length);
        return possibleTextArray[randomIndex];
    }
}
