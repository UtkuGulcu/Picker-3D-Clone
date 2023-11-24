using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSound : MonoBehaviour
{
    [SerializeField] private GameEventSO OnCollectableCollisionSound;
    
    private bool hasCollidedWithPlayer;
    private bool hasCollidedWithFillAreaGround;
    
    // Sends bool parameter to adjust volume depending on the collision type
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player") && !hasCollidedWithPlayer)
        {
            hasCollidedWithPlayer = true;
            OnCollectableCollisionSound.Raise(this, false);
        }

        if (other.transform.CompareTag("Fill Area Ground") && !hasCollidedWithFillAreaGround)
        {
            hasCollidedWithFillAreaGround = true;
            OnCollectableCollisionSound.Raise(this, true);
        }
    }
}
