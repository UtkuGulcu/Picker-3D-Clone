using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float launchForce;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y <= -4f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch()
    {
        rb.AddForce(Vector3.forward * launchForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Gets called after the spawn of the multiplier
    public void PlaySpawnAnimation()
    {
        float minSpawnForce = 10f;
        float maxSpawnForce = 18f;
        float spawnForce = Random.Range(minSpawnForce, maxSpawnForce);
        
        rb.AddForce(Vector3.up * spawnForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
