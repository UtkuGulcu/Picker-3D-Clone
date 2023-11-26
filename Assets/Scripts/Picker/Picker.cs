using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PickerDataSO pickerDataSO;
    
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;
    private int growSizeCount;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        StartUI.OnGameStarted += OnGameStarted;
        LevelCompleteUI.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        StartUI.OnGameStarted -= OnGameStarted;
        LevelCompleteUI.OnGameStarted -= OnGameStarted;
    }

    private void OnGameStarted(object sender, EventArgs e)
    {
        playerMovement.enabled = true;
        playerInput.enabled = true;
    }

    public void GoBackToLevelStartPosition()
    {
        transform.position = LevelManager.Instance.GetLevelStartingLocation();
        float floorOffset = 0.173f;
        transform.position += new Vector3(0, floorOffset, 0);
    }
    
    public void OnReachedRewardBlock()
    {
        playerMovement.EnableRewardAreaSpeed();
    }

    public void GrowPickerSize()
    {
        StartCoroutine(GrowPickerSizeCoroutine());
    }
    
    private IEnumerator GrowPickerSizeCoroutine()
    {
        growSizeCount++;

        Vector3 startScale = transform.localScale;

        Vector3 endScale = growSizeCount switch
        {
            1 => pickerDataSO.firstBigSize,
            2 => pickerDataSO.secondBigSize,
            _ => transform.localScale
        };

        float timer = 0f;
        float duration = 0.5f;
        
        while (timer <= duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, timer / duration);
            yield return Helpers.GetWaitForEndOfFrame();
        }
    }

    public void ResetPickerSize()
    {
        transform.localScale = pickerDataSO.defaultSize;
    }

    public void ResetGrowSizeCount()
    {
        growSizeCount = 0;
    }
}
