using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class FillAreaSuccessUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject visuals;
    [SerializeField] private TMP_Text panelText;
    [SerializeField] private FillAreaSuccessUIDataSO fillAreaSuccessUIDataSO;

    private FillAreaSuccessUIAnimation fillAreaSuccessUIAnimation;

    private void Awake()
    {
        fillAreaSuccessUIAnimation = GetComponent<FillAreaSuccessUIAnimation>();
    }

    public void EnableVisuals()
    {
        panelText.text = fillAreaSuccessUIDataSO.GetRandomText();
        visuals.SetActive(true);
        fillAreaSuccessUIAnimation.PlaySpawnAnimation();
    }

    public void DisableVisuals()
    {
        visuals.SetActive(false);
    }
}
