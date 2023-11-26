using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO OnLevelFinished;
    [SerializeField] private GameEventSO OnLevelTransitionStarted;

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
        float clampedX = Mathf.Clamp(targetPosition.x, -1.7f, 1.5f);
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
        float rewardAreaSpeed = Random.Range(pickerDataSO.rewardAreaMinSpeed, pickerDataSO.rewardAreaMaxSpeed);
        verticalSpeed = rewardAreaSpeed;

        StartCoroutine(StartSlowingDown(verticalSpeed, 0));
    }

    private IEnumerator StartSlowingDown(float startSpeed, float endSpeed)
    {
        yield return Helpers.GetWait(2);

        float lerpTime = 0f;
        float duration = 1f;
        
        while (lerpTime <= duration)
        {
            lerpTime += Time.deltaTime;
            verticalSpeed = Mathf.Lerp(startSpeed, endSpeed, lerpTime / duration);
            yield return Helpers.GetWaitForEndOfFrame();
        }
        
        RewardAreaControl.Instance.OnPickerStopped();

        yield return Helpers.GetWait(1);

        StartCoroutine(GoToNextLevelStartPosition());
    }

    private IEnumerator GoToNextLevelStartPosition()
    {
        OnLevelTransitionStarted.Raise();
        playerInput.enabled = false;
        
        // Go to next level starting position with constant speed until getting close
        Vector3 target = LevelManager.Instance.GetLevelStartingLocation();
        Vector3 direction = (target - transform.position).normalized;
        float speed = 25f;
        
        float distance = Vector3.Distance(transform.position, target);
        
        while (distance >= 8f)
        {
            distance = Vector3.Distance(transform.position, target);
            transform.Translate(direction * (speed * Time.deltaTime));
            yield return Helpers.GetWaitForEndOfFrame();
        }
        
        // Slow down smoothly
        float lerpTime = 0f;
        float duration = 0.8f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = target;
        
        while (lerpTime <= duration)
        {
            lerpTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, pickerDataSO.rewardAreaSpeedCurve.Evaluate(lerpTime / duration));
            yield return Helpers.GetWaitForEndOfFrame();
        }

        transform.position = target;
        OnLevelFinished.Raise();
        enabled = false;
    }
}
