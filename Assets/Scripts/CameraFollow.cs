using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float offset;

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, targetTransform.position.z + offset);
    }
}
