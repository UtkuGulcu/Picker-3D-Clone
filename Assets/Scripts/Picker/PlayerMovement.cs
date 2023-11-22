using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnLevelFinished;
    
    [Header("Values")] 
    [SerializeField] private PickerDataSO pickerDataSO;

    private float horizontalSpeed;
    private float verticalSpeed;
    
    private PlayerInput playerInput;
    private Rigidbody rb;
    private Vector3 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        horizontalSpeed = pickerDataSO.horizontalSpeed;
        verticalSpeed = pickerDataSO.verticalSpeed;
    }

    private void FixedUpdate()
    {
        targetPosition = Vector3.zero;

        HandleVerticalMovement();
        HandleHorizontalMovement();
        Move();
    }

    private void HandleVerticalMovement()
    {
        targetPosition += rb.position + Vector3.forward * (verticalSpeed * Time.fixedDeltaTime);
    }

    private void HandleHorizontalMovement()
    {
        if (!playerInput.IsDragging() || !playerInput.enabled) return;
        
        targetPosition += Vector3.right * (horizontalSpeed * playerInput.GetDragAmount() * Time.fixedDeltaTime);
        float clampedX = Mathf.Clamp(targetPosition.x, -1.94f, 1.76f);
        targetPosition = new Vector3(clampedX, targetPosition.y, targetPosition.z);
    }

    private void Move()
    {
        rb.MovePosition(targetPosition);
    }

    public void DisableVerticalMovement()
    {
        verticalSpeed = 0;
    }
    
    public void EnableVerticalMovement()
    {
        verticalSpeed = pickerDataSO.verticalSpeed;
    }

    public void EnableRewardAreaSpeed()
    {
        verticalSpeed = pickerDataSO.rewardAreaSpeed;
    }

    public void StartSlowingDown()
    {
        StartCoroutine(SlowDown(verticalSpeed, 0));
    }

    private IEnumerator SlowDown(float startSpeed, float endSpeed)
    {
        float lerpTime = 0f;
        float duration = 1f;
        
        while (lerpTime <= duration)
        {
            lerpTime += Time.deltaTime;
            verticalSpeed = Mathf.Lerp(startSpeed, endSpeed, lerpTime / duration);
            yield return Helpers.GetWaitForEndOfFrame();
        }

        StartCoroutine(GoToNextLevelStartPosition());
    }

    private IEnumerator GoToNextLevelStartPosition()
    {
        playerInput.enabled = false;
        
        Vector3 target = LevelManager.Instance.GetLevelStartingLocation();
        Vector3 direction = (target - transform.position).normalized;
        float speed = 8;

        float distance = Vector3.Distance(transform.position, target);

        
        while (distance >= 0.1f)
        {
            distance = Vector3.Distance(transform.position, target);
            transform.Translate(direction * (speed * Time.deltaTime));
            yield return Helpers.GetWaitForEndOfFrame();
        }

        transform.position = target;
        OnLevelFinished.Raise();
        enabled = false;
    }
}
