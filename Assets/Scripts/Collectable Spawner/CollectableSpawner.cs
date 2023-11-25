using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollectableSpawner : MonoBehaviour
{
    private enum MovementType
    {
        ZigZagMovement,
        CurvedMovement
    }
    
    [Header("References")]
    [SerializeField] private Transform wingTransform;
    [SerializeField] private GameObject collectable;
    [SerializeField] private Transform spawnPointTransform;
    
    [Header("Values")]
    [SerializeField] private MovementType movementType;
    [SerializeField] private int spawnCount;

    private CollectableSpawnerAnimation collectableSpawnerAnimation;
    private bool isActive;
    private float spawnTimer;
    private int objectPoolID;

    private void Awake()
    {
        collectableSpawnerAnimation = GetComponent<CollectableSpawnerAnimation>();
    }

    private void Start()
    {
        objectPoolID = ObjectPoolManager.Instance.CreatePool(collectable, spawnCount);
    }

    private void Update()
    {
        RotateWings();
        HandleVerticalMovement();
        HandleSpawning();
    }

    private void RotateWings()
    {
        float rotateSpeed = 720f;
        wingTransform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void HandleVerticalMovement()
    {
        if (!isActive)
        {
            return;
        }

        float verticalSpeed = 4f;
        transform.Translate(Vector3.forward * (verticalSpeed * Time.deltaTime));
    }

    private void HandleSpawning()
    {
        if (!isActive)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 0.06f)
        {
            spawnTimer = 0;
            ObjectPoolManager.Instance.SpawnFromPool(objectPoolID, spawnPointTransform.position,
                collectable.transform.eulerAngles);
        }
    }

    public void EnableSpawning()
    {
        isActive = true;
        StartCoroutine(WaitToDisableSpawning());

        if (movementType == MovementType.ZigZagMovement)
        {
            collectableSpawnerAnimation.PlayZigZagMovementAnimation();
        }
        else
        {
            collectableSpawnerAnimation.PlayCurvedMovementAnimation();
        }
    }

    private IEnumerator WaitToDisableSpawning()
    {
        yield return Helpers.GetWait(3.1f);
        isActive = false;
    }
}
