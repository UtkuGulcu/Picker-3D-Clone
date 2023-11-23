using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform wingTransform;
    [SerializeField] private GameObject collectable;
    [SerializeField] private Transform spawnPointTransform;

    [Header("Values")]
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float verticalSpeed;

    private CollectableSpawnerAnimation collectableSpawnerAnimation;
    private bool isActive;
    private float spawnTimer;

    private void Awake()
    {
        collectableSpawnerAnimation = GetComponent<CollectableSpawnerAnimation>();
    }

    private void Update()
    {
        RotateWings();
        HandleVerticalMovement();
        HandleSpawning();
    }

    private void RotateWings()
    {
        wingTransform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void HandleVerticalMovement()
    {
        if (!isActive)
        {
            return;
        }
        
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
            Instantiate(collectable, spawnPointTransform.position, Quaternion.Euler(270, 0, 0));
        }
    }

    public void EnableSpawning()
    {
        isActive = true;
        StartCoroutine(WaitToDisableSpawning());
        collectableSpawnerAnimation.PlayZigZagAnimation();
    }

    private IEnumerator WaitToDisableSpawning()
    {
        yield return Helpers.GetWait(3.1f);
        isActive = false;
    }
}
