using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float launchForce;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch()
    {
        rb.AddForce(Vector3.forward * launchForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
